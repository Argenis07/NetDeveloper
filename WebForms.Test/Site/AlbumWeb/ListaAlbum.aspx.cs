using DataAccess;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebForms.Test.Site.AlbumWeb
{
    public partial class ListaAlbum : System.Web.UI.Page
    {
        private UnitOfWork _unit;

        public ListaAlbum()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<Album> albums = _unit.Albums.GetAlbumsByStore();
            List<Album> listaalbums = albums.ToList();

            AlbumGridView.DataSource = listaalbums;
            AlbumGridView.DataBind();
        }

        protected void AlbumGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            AlbumGridView.PageIndex = e.NewPageIndex;

            int pageindex = e.NewPageIndex + 1;
            int pagesize = AlbumGridView.PageSize;

            IEnumerable<Album> albums = _unit.Albums.GetAlbumsPage(pageindex, pagesize);
            List<Album> listaalbums = albums.ToList();

            AlbumGridView.DataSource = listaalbums;
            AlbumGridView.DataBind();

            AlbumGridView.BottomPagerRow.Visible = true;
        }

        protected void btnfirst_Click(object sender, EventArgs e)
        {
            AlbumGridView.SelectedIndex = 0;
            AlbumGridView.PageIndex = 0;
            AlbumGridView.DataBind();
        }

        protected void btnlast_Click(object sender, EventArgs e)
        {
            int lasindex = AlbumGridView.Rows.Count - 1;
            AlbumGridView.SelectedIndex = lasindex;

            int lastpage = AlbumGridView.PageCount - 1;
            AlbumGridView.PageIndex = lastpage;
            AlbumGridView.DataBind();
        }
    }
}