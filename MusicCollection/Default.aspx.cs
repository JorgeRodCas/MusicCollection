using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            fillAlbums();
        }
    }

    private void fillAlbums()
    {
        Requester requester = new Requester();

        ddlAlbums.DataTextField = "title";
        ddlAlbums.DataValueField = "id";
        ddlAlbums.DataSource = requester.getAlbums();
        ddlAlbums.DataBind();
    }

    protected void btnVisualizeAlbum_Click(object sender, EventArgs e)
    {
        Requester requester = new Requester();
        repPhotos.DataSource = requester.getPhotos(int.Parse(ddlAlbums.SelectedValue));
        repPhotos.DataBind();
    }
}