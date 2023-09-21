using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Test.Site.ArtistWeb
{
    public partial class CrearArtist : System.Web.UI.Page
    {
        private UnitOfWork _unit;
        public CrearArtist()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btncrear_Click(object sender, EventArgs e)
        {
            var artista = new Artist { Name = txtname.Text };
            _unit.Artists.Add(artista);
            if(_unit.Complete()>0)
            {
                Response.Redirect("ListaArtist.aspx");
            }
        }
    }
}