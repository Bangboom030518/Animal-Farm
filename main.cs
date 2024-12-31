using System;
using Animals;

namespace Program
{
  /***
    <summary>
      The <c>Init</c> class is where the program is run, using infrastructure from the <c>Animals</c> namespace.
    </summary>
  */
  class Init
  {
    public static void Main(string[] args)
    {
      Human william = new Human("William");
      Goat johnny = new Goat("Johnny");
      // william.Vegetarian = true;
      william.Eat(johnny);
      william.Shoot(johnny);
    }
  }
}