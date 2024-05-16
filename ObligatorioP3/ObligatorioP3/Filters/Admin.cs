﻿using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace ObligatorioP3.Filters
{
    public class Admin : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            string rol = context.HttpContext.Session.GetString("rol");
            if (string.IsNullOrEmpty(rol))
            {
                context.Result = new RedirectResult("/");
                return;
            }
            if (rol != "Admin") // Cambia "Admin" según lo que establezcas en tu acción Login
            {
                context.Result = new RedirectResult("/");
                return;
            }
        }
    }
}
