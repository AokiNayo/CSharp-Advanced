using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            IShape shape;
            shape = new Circle();
            shape = new Rectangle();
            shape = new Square();
            GraphicEditor graphicEditor = new GraphicEditor();

            graphicEditor.DrawShape(shape);

        }
    }
}
