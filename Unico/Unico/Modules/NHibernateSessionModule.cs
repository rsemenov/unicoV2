using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate;
using NHibernate.Context;
using Unico.Modules.RequestFilters;

namespace Unico.Modules
{
    public class NHibernateSessionModule : IHttpModule
    {
        private static ISessionFactory _sessionFactory;
        private static IRequestFilter _requestFilter;

        public static void InitSessionFactory(ISessionFactory sessionFactory, IRequestFilter requestFilter)
        {
            _sessionFactory = sessionFactory;
            _requestFilter = requestFilter;
        }

        // Initializes the HTTP module
        public void Init(HttpApplication context)
        {            
            context.BeginRequest += BeginRequest;
            context.EndRequest += EndRequest;
        }

        // Disposes the HTTP module
        public void Dispose() { }

        // Opens the session, begins the transaction, and binds the session
        private void BeginRequest(object sender, EventArgs e)
        {
            var appContext = sender as HttpApplication;
            if (appContext == null)
                return;

            if (!_requestFilter.IsServiceRequest(appContext.Request.AppRelativeCurrentExecutionFilePath))
            {
                ISession session = _sessionFactory.OpenSession();

                session.BeginTransaction();

                CurrentSessionContext.Bind(session);
            }
        }

        // Unbinds the session, commits the transaction, and closes the session
        private void EndRequest(object sender, EventArgs e)
        {
            ISession session = CurrentSessionContext.Unbind(_sessionFactory);

            if (session == null) 
                return;

            try
            {
                session.Transaction.Commit();
            }
            catch (Exception)
            {
                session.Transaction.Rollback();
            }
            finally
            {
                session.Close();
                session.Dispose();
            }
        }
    }
}