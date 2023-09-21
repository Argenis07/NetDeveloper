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
    public partial class ListaArtist : System.Web.UI.Page
    {
        private UnitOfWork _unit;

        public ListaArtist()
        {
            _unit = new UnitOfWork(new ChinookContext());
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            //IEnumerable<Artist> artistas = _unit.Artists.GetArtistsByStore();
            //List<Artist> listaartistas = artistas.ToList();

            //ArtistGridView.DataSource = listaartistas;
            //ArtistGridView.DataBind();
            if(!IsPostBack)
            {
                cargar_datos(1);
            }
        }

        protected void btnfirst_Click(object sender, EventArgs e)
        {
            cargar_datos(1);
            //ArtistGridView.SelectedIndex = 0;
            //ArtistGridView.PageIndex = 0;
            //ArtistGridView.DataBind();
        }

        protected void btnlast_Click(object sender, EventArgs e)
        {
            int lasindex = ArtistGridView.Rows.Count - 1;
            ArtistGridView.SelectedIndex = lasindex;

            int lastpage = ArtistGridView.PageCount - 1;
            ArtistGridView.PageIndex = lastpage;
            ArtistGridView.DataBind();
        }

        protected void btnbuscar_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtnombre.Text))
            {
                int pageindex = int.Parse(lblpagina.Text);
                cargar_datos(pageindex);
                //IEnumerable<Artist> artistas = _unit.Artists.GetArtistsByStore();
                //List<Artist> listaartistas = artistas.ToList();

                //ArtistGridView.DataSource = listaartistas;
                //ArtistGridView.DataBind();
            }
            else
            {
                Artist artista = _unit.Artists.GetByName(txtnombre.Text);
                List<Artist> listaartistas = new List<Artist>();
                listaartistas.Add(artista);
                ArtistGridView.DataSource = listaartistas;
                ArtistGridView.DataBind();
            }
        }

        protected void ArtistGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            ArtistGridView.PageIndex = e.NewPageIndex;

            int pageindex = e.NewPageIndex + 1;
            int pagesize = ArtistGridView.PageSize;

            IEnumerable<Artist> artistas = _unit.Artists.GetArtistsPage(pageindex, pagesize);
            List<Artist> listaartistas = artistas.ToList();

            ArtistGridView.DataSource = listaartistas;
            ArtistGridView.DataBind();

            ArtistGridView.BottomPagerRow.Visible = true;
        }

        protected void btnnext_Click(object sender, EventArgs e)
        {
            int pageindex = int.Parse(lblpagina.Text) + 1;
            cargar_datos(pageindex);
        }

        protected void btnprev_Click(object sender, EventArgs e)
        {
            int pageindex = int.Parse(lblpagina.Text) - 1;
            if (pageindex>0)
            {
                cargar_datos(pageindex);
            }
        }

        public void cargar_datos(int index)
        {
            int pagesize = ArtistGridView.PageSize;
            int pageindex = index;

            IEnumerable<Artist> artistas = _unit.Artists.GetArtistsPage(pageindex, pagesize);
            List<Artist> listaartistas = artistas.ToList();

            ArtistGridView.DataSource = listaartistas;
            ArtistGridView.DataBind();
            actualizar_paginacion(pageindex);
        }

        public void actualizar_paginacion(int index)
        {
            lblpagina.Text = index.ToString();
        }

        public int total_registros()
        {
            return _unit.Artists.Count();
        }

        public int total_paginas()
        {
            int pagesize = ArtistGridView.PageSize;
            int index = (int)Math.Ceiling((decimal)total_registros() / pagesize);
            return index;
        }
    }
}