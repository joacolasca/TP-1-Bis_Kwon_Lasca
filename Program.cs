using System.Collections.Generic;
int cursos = 0, estudiantes = 0, dineroTotal = 0, cursoMayor = 0, recaudacionTotal = 0, cantCursos = 0;
bool salir = false;
float promedio = 0;
Dictionary<int, int> dicCurso = new Dictionary<int, int>();
do
{
    menu(ref dicCurso, ref cursos, ref estudiantes, cursoMayor, promedio, recaudacionTotal, cantCursos, ref salir);
} while (salir == false);


void ingresarCursoYEstudiantes(ref Dictionary<int, int> dicCurso, ref int cursos, ref int estudiantes)
{
    int dinero = 0, dineroTotal = 0;
    Console.WriteLine("Ingrese su curso");
    cursos = int.Parse(Console.ReadLine());
    Console.WriteLine("Ingrese la cantidad de estudiantes");
    estudiantes = int.Parse(Console.ReadLine());
    for (int i = 0; i < estudiantes; i++)
    {
        do{
        Console.WriteLine("Ingrese el dinero que quiere aportar");
        dinero = int.Parse(Console.ReadLine());
        }
        while(dinero == 0);
        dineroTotal = dineroTotal + dinero;

    }
    dicCurso.Add(cursos, dineroTotal);
}
void calcularEstadisticas(Dictionary<int, int> dicCurso, ref int cursoMayor, ref int recaudacionTotal, ref int cantCursos, ref float promedio)
{
    int valorMaximo = dicCurso.Values.Max();
    foreach (var par in dicCurso)
    {
        if (par.Value == valorMaximo)
        {
            cursoMayor = par.Key;
        }
    }
    foreach (int valor in dicCurso.Values)
    {
        recaudacionTotal = recaudacionTotal + valor;
    }
    cantCursos = dicCurso.Count;
    promedio = recaudacionTotal / cantCursos;
}
void mostrarEstadisticas(int cursoMayor, float promedio, int recaudacionTotal, int cantCursos)
{
    Console.WriteLine("El curso que mas plata puso es el: " + cursoMayor);
    Console.WriteLine("El promedio de plata regalado por todos los cursos es de: " + promedio);
    Console.WriteLine("La recaudación total entre los todos cursos es de: " + recaudacionTotal);
    Console.WriteLine("La cantidad de cursos que participan del regalo es: " + cantCursos);
}
void menu(ref Dictionary<int, int> dicCurso, ref int cursos, ref int estudiantes, int cursoMayor, float promedio, int recaudacionTotal, int cantCursos, ref bool salir)
{
    int opcion;
    Console.WriteLine("Ingresar opcion entre: 1) Ingrese los importes de un curso, 2) Ver estadísticas, 3) Salir");
    opcion = int.Parse(Console.ReadLine());
    switch (opcion)
    {
        case 1: ingresarCursoYEstudiantes(ref dicCurso, ref cursos, ref estudiantes);
        break;
        case 2: calcularEstadisticas(dicCurso, ref cursoMayor, ref recaudacionTotal, ref cantCursos, ref promedio);
        mostrarEstadisticas(cursoMayor, promedio, recaudacionTotal, cantCursos);
        break;
        case 3: salir = true;
        break;
    }
}