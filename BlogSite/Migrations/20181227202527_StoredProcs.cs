using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BlogSite.Migrations
{
    public partial class StoredProcs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceNames =
                assembly.GetManifestResourceNames().Where(str => str.EndsWith(".sql"));
            foreach (string resourceName in resourceNames)
            {
                using (Stream stream = assembly.GetManifestResourceStream(resourceName))
                using (StreamReader reader = new StreamReader(stream))
                {
                    string sql = reader.ReadToEnd();
                    migrationBuilder.Sql(sql);
                }
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
