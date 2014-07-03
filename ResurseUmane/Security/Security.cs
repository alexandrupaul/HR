using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using ResurseUmane.Utils;

namespace ResurseUmane
{
    public class Security
    {
        private HttpSessionState _session { get; set; }
        private string _redirectUrl { get; set; }
        private HttpServerUtility _server { get; set; }
        private HttpResponse _response { get; set; }
        private HttpRequest _request { get; set; }
        public string Username
        {
            get
            {
                return this._session["logged_in_id"] != null ? this._session["logged_in_id"].ToString() : "";
            }
            private set { }
        }

        public Security(HttpSessionState session, HttpServerUtility server, HttpResponse response, HttpRequest request ,string redirectUrl)
        {
            this._session = session;
            this._redirectUrl = redirectUrl;
            this._response = response;
            this._request = request;
        }

        public void Login(string Username, string Password)
        {
            if (int.Parse(new Utils.Procedure("dbo.autentificaUtilizator")
                            .AddParameter("@Utilizator", Username)
                            .AddParameter("@Parola", Password)
                            .ExecuteScalar()) > 0)
            {
                this._session["logged_in_id"] = Username;
            }
            this._response.Redirect(this._redirectUrl);
        }

        public bool IsLoggedIn()
        {
            this.CheckLogin();
            return this._session["logged_in_id"] != null;
        }

        public void CheckLogin()
        {
            if (this._session["logged_in_id"] == null && this._request.Url.ToString().IndexOf("Default.aspx") == -1)
            {
                this._response.Redirect(this._redirectUrl);
            }
        }

        public void Logout()
        {
            this._session.Clear();
            this._response.Redirect(this._redirectUrl);
        }
    }
}