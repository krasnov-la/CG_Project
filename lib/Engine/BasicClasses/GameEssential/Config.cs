using System.Text.Json;
namespace CGProject.Engine
{
    public class Configuration
    {
        public int HorizontalBlocks { get;set;}
        public int VerticalBlocks { get;set;}
        public float HorizontalFoV { get;set;}
        public float VerticalFoV { get;set;}
        public float DrawDist { get;set;}
        public int FPS { get; set; }
        public Configuration() { }      
    }
}
