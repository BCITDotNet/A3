using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Collections;
using System.Drawing;
using System.Net;




public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ImageButtonFirst.Visible = false;
        ImageButtonPrev.Visible = false;
        ImageButtonLast.Visible = false;
        ImageButtonNext.Visible = false;
        ImageButtonDownload.Visible = false;
        ImageButtonPrint.Visible = false;
        TextBoxResult.ReadOnly = true;
    }

    ArrayList foundDatas;
    ArrayList foundFilePath;

    protected void Search_Click(object sender, EventArgs e)
    {
        string[] searchWords = TextBoxSearch.Text.Split(' ');
        string[] exclusion = System.IO.File.ReadAllLines(Server.MapPath("exclusion/exclusion.txt"));
        searchWords = searchWords.Except(exclusion).ToArray();
        searchWords = searchWords.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        bool noResult = true;

        if (searchWords.Count() > 0)
        {
            foundDatas = new ArrayList();
            foundFilePath = new ArrayList();

            string[] fileArray = System.IO.Directory.GetFiles(Server.MapPath("files"));

            foreach (string filePath in fileArray)
            {
                string text = System.IO.File.ReadAllText(filePath);

                foreach (string word in searchWords)
                {
                    if (text.Contains(word))
                    {
                        foundFilePath.Add(filePath);
                        foundDatas.Add(text);
                        break;
                    }
                }
            }

            if (foundFilePath.Count > 0)
            {
                setFirstFile();
                Session["foundDatas"] = foundDatas;
                Session["foundFilePath"] = foundFilePath;
                noResult = false;
            }
           
        }
        if(noResult)
        {
            LabelFileName.Text = "";
            LabelNumber.Text = "";
            TextBoxResult.Text = "";
        }

    }

    protected void setFirstFile()
    {

        LabelFileName.Text = Path.GetFileName(foundFilePath[0].ToString());
        TextBoxResult.Text = foundDatas[0].ToString();

        Session["index"] = 0;
        LabelNumber.Text = 1 + "/" + foundFilePath.Count;
        if (foundFilePath.Count > 0)
        {
            ImageButtonLast.Visible = true;
            ImageButtonNext.Visible = true;
        }

        ImageButtonDownload.Visible = true;
        ImageButtonPrint.Visible = true;
    }


    protected void ImageButtonFirst_Click(object sender, ImageClickEventArgs e)
    {
        FirstThing();
        setFirstFile();
    }

    protected void ImageButtonLast_Click(object sender, ImageClickEventArgs e)
    {
        FirstThing();

        int last = foundFilePath.Count - 1;
        LabelFileName.Text = Path.GetFileName(foundFilePath[last].ToString());
        TextBoxResult.Text = foundDatas[last].ToString();

        Session["index"] = last;
        last++;
        LabelNumber.Text = last + "/" + last;
        if (foundFilePath.Count > 0)
        {
            ImageButtonFirst.Visible = true;
            ImageButtonPrev.Visible = true;
        }
    }
    protected void ImageButtonNext_Click(object sender, ImageClickEventArgs e)
    {
        FirstThing();
        int index = (int)Session["index"];

        LabelFileName.Text = Path.GetFileName(foundFilePath[++index].ToString());
        TextBoxResult.Text = foundDatas[index].ToString();

        if (index != foundFilePath.Count - 1)
        {
            ImageButtonLast.Visible = true;
            ImageButtonNext.Visible = true;
        }
        ImageButtonFirst.Visible = true;
        ImageButtonPrev.Visible = true;
        Session["index"] = index;
        LabelNumber.Text = ++index + "/" + foundFilePath.Count;


    }
    protected void ImageButtonPrev_Click(object sender, ImageClickEventArgs e)
    {
        FirstThing();
        int index = (int)Session["index"];

        LabelFileName.Text = Path.GetFileName(foundFilePath[--index].ToString());
        TextBoxResult.Text = foundDatas[index].ToString();

        if (index != 0)
        {
            ImageButtonFirst.Visible = true;
            ImageButtonPrev.Visible = true;
        }
        ImageButtonLast.Visible = true;
        ImageButtonNext.Visible = true;

        Session["index"] = index;
        LabelNumber.Text = ++index + "/" + foundFilePath.Count;

    }

    protected void FirstThing()
    {
        ImageButtonDownload.Visible = true;
        ImageButtonPrint.Visible = true;
        foundDatas = (ArrayList)Session["foundDatas"];
        foundFilePath = (ArrayList)Session["foundFilePath"];
    }

    protected void ImageButtonDownload_Click(object sender, ImageClickEventArgs e)
    {
        string name = LabelFileName.Text;
        string filepath = Server.MapPath("files/")+name;
        Response.Clear();
       Response.ClearContent();
        Response.ContentType = "text/plain";
        Response.AddHeader("Content-Disposition", "attachment; filename=" + name + ";");
        Response.TransmitFile(filepath);
        Response.End();
    }
    protected void ImageButtonPrint_Click(object sender, ImageClickEventArgs e)
    {
        var fileName = LabelFileName.Text;
        Response.Write("<script>");
        Response.Write("w = window.open('/files/" + fileName + "');");
        Response.Write("w.print();");
        Response.Write("</script>");
        Response.End();
    }
}