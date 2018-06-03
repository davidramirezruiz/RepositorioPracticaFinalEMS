namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateEvaluaciones : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsignacionDocentes",
                c => new
                    {
                        AsignacionDocenteId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        GrupoClaseId = c.Int(nullable: false),
                        CursoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.AsignacionDocenteId)
                .ForeignKey("dbo.Cursos", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.GrupoClases", t => t.GrupoClaseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.GrupoClaseId)
                .Index(t => t.CursoId);
            
            CreateTable(
                "dbo.Evaluaciones",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CursoId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Convocatoria = c.Int(nullable: false),
                        Trabajo1 = c.Int(nullable: false),
                        Trabajo2 = c.Int(nullable: false),
                        Trabajo3 = c.Int(nullable: false),
                        Test = c.Int(nullable: false),
                        Practica = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cursos", t => t.CursoId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.CursoId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Matriculas",
                c => new
                    {
                        MatriculasId = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        GrupoClaseId = c.Int(nullable: false),
                        CursosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.MatriculasId)
                .ForeignKey("dbo.Cursos", t => t.CursosId, cascadeDelete: true)
                .ForeignKey("dbo.GrupoClases", t => t.GrupoClaseId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.GrupoClaseId)
                .Index(t => t.CursosId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Matriculas", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Matriculas", "GrupoClaseId", "dbo.GrupoClases");
            DropForeignKey("dbo.Matriculas", "CursosId", "dbo.Cursos");
            DropForeignKey("dbo.Evaluaciones", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Evaluaciones", "CursoId", "dbo.Cursos");
            DropForeignKey("dbo.AsignacionDocentes", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AsignacionDocentes", "GrupoClaseId", "dbo.GrupoClases");
            DropForeignKey("dbo.AsignacionDocentes", "CursoId", "dbo.Cursos");
            DropIndex("dbo.Matriculas", new[] { "CursosId" });
            DropIndex("dbo.Matriculas", new[] { "GrupoClaseId" });
            DropIndex("dbo.Matriculas", new[] { "UserId" });
            DropIndex("dbo.Evaluaciones", new[] { "UserId" });
            DropIndex("dbo.Evaluaciones", new[] { "CursoId" });
            DropIndex("dbo.AsignacionDocentes", new[] { "CursoId" });
            DropIndex("dbo.AsignacionDocentes", new[] { "GrupoClaseId" });
            DropIndex("dbo.AsignacionDocentes", new[] { "UserId" });
            DropTable("dbo.Matriculas");
            DropTable("dbo.Evaluaciones");
            DropTable("dbo.AsignacionDocentes");
        }
    }
}
