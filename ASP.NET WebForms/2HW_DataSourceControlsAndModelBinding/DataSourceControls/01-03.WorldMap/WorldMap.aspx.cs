using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace _01_03.WorldMap
{
    public partial class WorldMap : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected string GetImage(object img)
        {
            string result = "";
            if (img != null)
            {
                result = "data:image/jpg;base64," + Convert.ToBase64String((byte[])img);
            }
            return result;
        }

        protected void btnAddContinent_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBoxContinent.Text))
            {
                WorldMapEntities db = new WorldMapEntities();

                db.Continents.Add(new Continent()
                {
                    Name = textBoxContinent.Text
                });

                db.SaveChanges();
                ListBoxContinents.DataBind();
            }
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
        }

        protected void btnDeleteContinent_Click(object sender, EventArgs e)
        {
            int continentId = this.ListBoxContinents.SelectedIndex;

            WorldMapEntities context = new WorldMapEntities();

            var continent = context.Continents.FirstOrDefault(x => x.ContinentId == continentId);

            context.Continents.Remove(continent);
            context.SaveChanges();
        }

        protected void UploadImage_Click(object sender, EventArgs e)
        {
            int editIndex = this.GridViewCountries.EditIndex;
            var fileUpload = this.GridViewCountries.Rows[editIndex].FindControl("UploadImage") as FileUpload;
            bool validation = false;
            if (fileUpload.HasFile)
            {
                validation = ValidateUploadFile(fileUpload.PostedFile.FileName);
            }
            if (validation)
            {
                if (fileUpload.HasFile)
                {
                    Byte[] imgByte = null;
                    HttpPostedFile File = fileUpload.PostedFile;
                    imgByte = new Byte[File.ContentLength];
                    File.InputStream.Read(imgByte, 0, File.ContentLength);

                    int selectedCountry;
                    if (int.TryParse(this.GridViewCountries.DataKeys[editIndex].Value.ToString(), out selectedCountry))
                    {
                        var context = new WorldMapEntities();
                        using (context)
                        {
                            var country = context.Countries.Find(selectedCountry);
                            if (country != null)
                            {
                                country.Flag = imgByte;
                                context.SaveChanges();
                                this.GridViewCountries.DataBind();
                            }
                        }
                    }
                }
            }
        }

        protected bool ValidateUploadFile(string fileName)
        {
            string[] validFileTypes = { "gif", "png", "jpg", "jpeg" };
            string ext = System.IO.Path.GetExtension(fileName);

            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    return true;
                }
            }

            return false;
        }


        protected void LinkButtonAddCountry_Click(object sender, EventArgs e)
        {
            WorldMapEntities context = new WorldMapEntities();

            int continentId = this.ListBoxContinents.SelectedIndex + 1;
            int languageId = this.DropDownListCountryLanguage.SelectedIndex + 1;
            string name = textBoxCountryName.Text;
            int population = int.Parse(textBoxCountryPopulation.Text);

            Country country = new Country()
            {
                ContinentId = continentId,
                LanguageId = languageId,
                Name = name,
                Population = population
            };

            context.Countries.Add(country);
            context.SaveChanges();
            this.GridViewCountries.DataBind();
        }

        protected void ButtonUpdateCountry_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButtonAddTown_Click(object sender, EventArgs e)
        {
            WorldMapEntities context = new WorldMapEntities();

            int countryId = this.GridViewCountries.SelectedIndex + 1;
            int population = int.Parse(this.TextBoxTownPopulation.Text);
            string name = this.TextBoxTownName.Text;
            Town town = new Town()
            {
                CountryId = countryId,
                Name = name,
                Population = population
            };

            context.Towns.Add(town);
            context.SaveChanges();
            this.ListViewTowns.DataBind();
        }

    }
}