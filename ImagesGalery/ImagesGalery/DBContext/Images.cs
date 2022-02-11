using SQLite;

namespace ImagesGalery.DBContext
{
    [Table("Images")]
    public class Images
    {
        [PrimaryKey, AutoIncrement, Column("id")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }
        [Column("path")]
        public string Path { get; set; }

    }
}
