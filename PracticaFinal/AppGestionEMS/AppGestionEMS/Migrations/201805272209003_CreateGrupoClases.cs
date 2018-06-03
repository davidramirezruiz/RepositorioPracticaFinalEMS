namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateGrupoClases : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GrupoClases",
                c => new
                    {
                        GrupoClaseId = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Plazas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GrupoClaseId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.GrupoClases");
        }
    }
}
