using System;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using AutoMapper;
using FitnessTracker.BLL.Interfaces;
using FitnessTracker.WEB.Auth.Interfaces;
using FitnessTracker.WEB.ViewModels.AuthModels;

namespace FitnessTracker.WEB.Auth.Principal
{
    public class Authentication : IAuthentication
    {
        private const string CookieName = "__AUTH_COOKIE";
        private const string HeaderName = "_Auth_Header";

        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private IPrincipal _currentUser;

        public Authentication(IMapper mapper, IUserService userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        public HttpContext HttpContext { private get; set; }

        public IPrincipal CurrentUser
        {
            get
            {
                if(_currentUser != null)
                {
                    return _currentUser;
                }

                if(CheckForAPIRequest())
                {
                    var ticketValue = HttpContext.Request.Headers[HeaderName];
                    if(ticketValue != null)
                    {
                        var ticket = FormsAuthentication.Decrypt(ticketValue);
                        _currentUser = ticket != null
                            ? new UserProvider(_userService, _mapper, ticket.Name)
                            : new UserProvider(null, null, null);
                    }
                    else
                    {
                        _currentUser = new UserProvider(null, null, null);
                    }
                }
                else
                {
                    var authCookie = HttpContext.Request.Cookies.Get(CookieName);
                    if(!string.IsNullOrEmpty(authCookie?.Value))
                    {
                        var ticket = FormsAuthentication.Decrypt(authCookie.Value);
                        if(ticket != null)
                        {
                            _currentUser = new UserProvider(_userService, _mapper, ticket.Name);
                        }
                    }
                    else
                    {
                        _currentUser = new UserProvider(null, null, null);
                    }
                }

                return _currentUser;
            }
        }

        public User Login(string userName, string password, bool isPersistent)
        {
            var retUser = _mapper.Map<User>(_userService.Login(userName, password));

            if(retUser != null)
            {
                CreateCookie(userName, isPersistent);
            }

            return retUser;
        }

        public void LogOut()
        {
            var httpCookie = HttpContext.Response.Cookies[CookieName];
            if(httpCookie != null)
            {
                httpCookie.Value = string.Empty;
            }
        }

        private void CreateCookie(string userName, bool isPersistent = false)
        {
            var ticket = new FormsAuthenticationTicket(
                1,
                userName,
                DateTime.Now,
                DateTime.Now.Add(FormsAuthentication.Timeout),
                isPersistent,
                string.Empty,
                FormsAuthentication.FormsCookiePath);

            // Encrypt the ticket.
            var encTicket = FormsAuthentication.Encrypt(ticket);

            // Create the cookie.
            var authCookie = new HttpCookie(CookieName)
            {
                Value = encTicket,
                Expires = DateTime.Now.Add(FormsAuthentication.Timeout)
            };
            HttpContext.Response.Cookies.Set(authCookie);
        }

        private bool CheckForAPIRequest()
        {
            var path = HttpContext.Current.Request.Url.AbsolutePath;
            var segments = path.Split('/');
            return segments[1].Equals("api");
        }
    }
}