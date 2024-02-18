using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form1 : Form
    {

        BindingSource albumBindingSource = new BindingSource();
        BindingSource tracksBindingSource = new BindingSource();

        List<Album> albums = new List<Album>();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           AlbumsDAO albumsDAO = new AlbumsDAO();


            //connect the list to the grid view control
            albums = albumsDAO.getAllAlbums();  

            albumBindingSource.DataSource = albumsDAO.getAllAlbums();

            dataGridView1.DataSource = albumBindingSource;

            pictureBox1.Load("https://upload.wikimedia.org/wikipedia/en/4/42/Beatles_-_Abbey_Road.jpg");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AlbumsDAO albumsDAO = new AlbumsDAO();


            //connect the list to the grid view control

            albumBindingSource.DataSource = albumsDAO.searchTitles(textBox1.Text);

            dataGridView1.DataSource = albumBindingSource;

          
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dataGridView = (DataGridView)sender;


            //get the row number clicked,

            int rowClicked = dataGridView.CurrentRow.Index;
        //    MessageBox.Show("You clikced row " + rowClicked);

        
            //     MessageBox.Show("URL" + imageURRL);

            //String imageURRL = dataGridView.Rows[rowClicked].Cells[0].Value.ToString();


          // pictureBox1.Load(imageURRL);

           

            tracksBindingSource.DataSource = albums[rowClicked].Tracks; 

            dataGridView2.DataSource = tracksBindingSource;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // add a new item to the database

            Album album = new Album
            {
                AlbumName = txt_albumName.Text,
                ArtistName = txt_Artist.Text,
                Year = Int32.Parse(txt_Year.Text),
                ImagUrl = txt_ImageUrl.Text,
                Description = txt_Description.Text,

            };

            AlbumsDAO albumsDAO = new AlbumsDAO();
            int result = albumsDAO.addOneAlbum(album);
            MessageBox.Show(result + "new row(s) inserted");
          
        }

        private void button4_Click(object sender, EventArgs e)
        {

            int rowClicked = dataGridView2.CurrentRow.Index;
             MessageBox.Show("You clikced row " + rowClicked);

            int trackID = (int) dataGridView2.Rows[rowClicked].Cells[0].Value;
            MessageBox.Show("ID of track" + trackID);

            AlbumsDAO albumsDAO =new AlbumsDAO();

            int result = albumsDAO.deleteTrack(trackID);

            MessageBox.Show("Result " + result);

            dataGridView2.DataSource = null;

            albums = albumsDAO.getAllAlbums();

        }
    }
}
