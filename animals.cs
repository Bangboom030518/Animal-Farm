using System;
using System.Reflection;
using System.Linq;

namespace Animals
{
  /***
    <summary>
      The <c>IAnimal</c> interface provides a structure for all animal classes.
    </summary>
  */
  interface IAnimal
  {
    void Born(string name);
    void Speak(string text = "");
    void Eat(Animal animal);
    void Die();
  }

  interface IMammal
  {
    void Walk(int distance);
    void Walk(double distance);
  }

  interface IBird
  {
    void Fly(int distance);
    void Fly(double distance);
  }

  abstract class Animal : IAnimal
  {
    public bool Alive = true;
    public string Name = "NAME YOUR ANIMALZ, YA FOOL!";
    public double[] Position = {0, 0};
    public static string Sound = "Say";
    public bool Vegetarian = false;

    public void Born(string name)
    {
      Name = name;
      Console.WriteLine($"{name} was born");
    }

    public void Speak(
      string text = ""
    )
    {
      string sound = this
        .GetType()
        .GetField("Sound")
        .GetValue(null)
        .ToString();

      string name = Alive ? Name : $"The Ghost Of {Name}";

      if (text == "")
      {
        text = sound;
      }

      Console.WriteLine($"{name} {sound.ToLower()}s \"{text}\"");
    }

    public void Eat(Animal animal)
    {
      if (Vegetarian)
      {
        Speak($"Eugh, I'm not eating {animal.Name}, they might have been rolling in the mud");
        return;
      }

      if (animal.Alive)
      {
        Console.WriteLine($"{Name} ate {animal.Name}");
        animal.Die();
        Speak("Yum Yum");
      }
      else
      {
        Console.WriteLine($"{Name} tried to eat {animal.Name}");
        animal.Speak("Haha, you can't eat ghosts! Looks like you'll just have to starve. Lolz!");
      }

    }

    public void Die()
    {
      if (Alive)
      {
        Alive = false;
        Console.WriteLine($"{Name} died - R.I.P {Name}!");
      } else {
        Speak("Haha, ghosts are immortal! Can't catch me!");
      }
    }
  }

  abstract class Bird : Animal, IBird
  {
    public static new string Sound = "Cheep";
    
    public void Fly(int distance)
    {
      Position[1] = 100;
      Position[0] += distance;
    }

    public void Fly(double distance)
    {
      Position[1] = 100;
      Position[0] += distance;
    }

  }

  class Duck : Bird
  {
    public static new string Sound = "Quack";

    public Duck(string name)
    {
      Born(name);
    }
  }

  abstract class Mammal : Animal, IMammal
  {
    public static new string Sound = "Grunt";

    public void Walk(int distance)
    {
      Position[0] += distance;
    }

    public void Walk(double distance)
    {
      Position[0] += distance;
    }
  }

  class Pig : Mammal
  {
    public static new string Sound = "Oink";

    public Pig(string name)
    {
      Born(name);
    }
  }
  
  class Goat : Mammal
  {
    public static new string Sound = "Bleat";

    public Goat(string name)
    {
      Born(name);
    }
  }

  class Human : Mammal
  {
    public static new string Sound = "Say";

    public Human(string name)
    {
      Born(name);
    }

    public void Shoot(Animal animal)
    {
      if (animal.Alive)
      {
        Console.WriteLine($"{Name} shot {animal.Name}");
        animal.Die();
      }
      else
      {
        Console.WriteLine($"{Name} tried to shoot {animal.Name}");
        animal.Speak("Haha, you can't shoot ghosts! Now put that gun down before you actually hurt someone.");
      }
    }
  }
}