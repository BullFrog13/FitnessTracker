using System;
using System.Web;
using System.Web.Mvc;
using FitnessTracker.WEB.Auth.Interfaces;

namespace FitnessTracker.WEB.HttpModules
{
    public class AuthHttpModule : IHttpModule
    {
        private HttpApplication _context;

        public void Dispose() { }

        public void Init(HttpApplication context)
        {
            _context = context;
            _context.AuthenticateRequest += OnBeginRequest;
        }

        private static void OnBeginRequest(object source, EventArgs e)
        {
            var context = ((HttpApplication)source).Context;

            var auth = DependencyResolver.Current.GetService<IAuthentication>();
            auth.HttpContext = context;
            context.User = auth.CurrentUser;
        }
    }
}