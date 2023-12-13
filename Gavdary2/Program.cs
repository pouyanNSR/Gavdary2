

List<Animal> animals = new List<Animal>()
{
new Cow()   { IsMale = true,IsShrdeh = false ,Weight = 450,BirthDate=new DateTime(2022,10,05)},
new Cow()   { IsMale = false,IsShrdeh = true ,Weight = 550,BirthDate=new DateTime(2021,06,07)},
new Sheep() { IsMale = true,IsShrdeh = false ,Weight = 600,BirthDate=new DateTime(2020,01,06)},
new Sheep() { IsMale = true,IsShrdeh = false ,Weight = 550,BirthDate=new DateTime(2022,06,03)},
new Cow()   { IsMale = false,IsShrdeh = true ,Weight = 640,BirthDate=new DateTime(2019,09,19)},
new Sheep() { IsMale = true,IsShrdeh = false ,Weight = 610,BirthDate=new DateTime(2020,06,09)},
new Sheep() { IsMale = false,IsShrdeh = false,Weight = 770,BirthDate=new DateTime(2015,11,07)},
new Cow()   { IsMale = false,IsShrdeh = true ,Weight = 690,BirthDate=new DateTime(2017,02,01)},
new Cow()   { IsMale = true,IsShrdeh = false ,Weight = 380,BirthDate=new DateTime(2023,05,20)},
new Sheep() { IsMale = false,IsShrdeh = false,Weight = 500,BirthDate=new DateTime(2021,07,19)},
new Sheep() { IsMale = false,IsShrdeh = true ,Weight = 560,BirthDate=new DateTime(2022,08,29)},
new Cow()   { IsMale = true,IsShrdeh = false ,Weight = 590,BirthDate=new DateTime(2020,11,28)},
new Sheep() { IsMale = true,IsShrdeh = false ,Weight = 670,BirthDate=new DateTime(2018,07,17)},
new Cow()   { IsMale = false,IsShrdeh = true ,Weight = 570,BirthDate=new DateTime(2019,10,13)},
new Sheep() { IsMale = true,IsShrdeh = false ,Weight = 650,BirthDate=new DateTime(2018,08,08)},
};

AnimalEnvironment env = new AnimalEnvironment()
{
    HealthParameterTDS = 4000,
    HealthParameterTemperature = 38.4,
    HealthParameterDensity = 1.2,
    HealthParameterDecibel = 6000,
    HealthParameterAQI = 100,
    HealthParameterOxygen = 80,

};

CowParameters cp = new CowParameters()
{
    HealthParameterTimeToStand = 70,
    HealthParameterTimeToDeal =36,
    HealthParameterTimeToRelax =220,
    HealthParameterNumberOfMeal =20,
    HealthParameterNumberOfMilkProduction = 22
};

foreach (Animal animal in animals)
{
    Console.WriteLine(animal);
    Console.WriteLine($"Number of Days To Die Is : {animal.TimeToDie()} Days");
    Console.WriteLine("-------------------------");
}


class HealthParameter<T>
{
    public string Name { get; set; }
    public T Current { get; set; }
    public T Standard { get; set; }
    public double Alpha { get; set; }
    public virtual double StressFactor() => (Convert.ToDouble(Current) / Convert.ToDouble(Standard)) * Alpha;

}
public abstract class Animal
{
    static Animal()
    {
        TotalNumber = 0;
    }
    public Animal()
    {
        TotalNumber++;
        Number = TotalNumber;
    }
    public static int TotalNumber { get; private set; }
    
    public int Number { get; private set; }
    public double Weight { get; set; }
    public bool IsMale { get; set; }
    public bool IsShrdeh { get; set; }
    public DateTime BirthDate { get; set; }
    public abstract double TimeToDie();    
    public abstract int Life();
    public abstract double killpriority();
    public abstract double CostPerDay();
    public List<IAnimalEnvironment> Environments { get; set; }

}
public class Cow : Animal
{
    static Cow() { MaxLife = 9125; }
    public static int MaxLife { get; }

    public override int Life()
    {
        int Age = (int)(DateTime.Now - BirthDate).TotalDays;

        return MaxLife - Age;
    }
   
    public override string ToString()
    {
        return 
               $"C{(IsMale ? 'M' : 'F')}..{BirthDate.Year}/{BirthDate.Month}/{BirthDate.Day}..No{Number}...KP:{killpriority().ToString("0.###")}"; 
    }
    public override double TimeToDie()
    {
        int Maxlife = 9125;

        return (Maxlife) - (Life());
    }

    public override double killpriority()
    {
        int Maxlife = 9125;
        double Zarib = (TimeToDie()) / (Maxlife);
        if (IsShrdeh == true)
            return Zarib + 0 / 3;
        else
            return 1 - Zarib;
    }
    
    public override double CostPerDay()
    {
        int GheymateShireKham = 20000;
        return (cp.HealthParameterNumberOfMilkProduction) * (GheymateShireKham);
    }
    CowParameters cp = new CowParameters()
    {
        HealthParameterTimeToStand = 70,
        HealthParameterTimeToDeal = 36,
        HealthParameterTimeToRelax = 220,
        HealthParameterNumberOfMeal = 20,
        HealthParameterNumberOfMilkProduction = 22
    };


}

public class Sheep : Animal
{
    public override int Life()
    {
        int Age = (int)(DateTime.Now - BirthDate).TotalDays;

        return MaxLife - Age;
    }
    static Sheep() { MaxLife = 4380; }
    public static int MaxLife { get; }
    public override string ToString()
    {
        return
        $"S{(IsMale ? 'M' : 'F')}..{BirthDate.Year}/{BirthDate.Month}/{BirthDate.Day}..No{Number}...KP:{killpriority().ToString("0.###")}";
    }
    public override double TimeToDie()
    {
        int Maxlife = 4380;
        int Age = (int)(DateTime.Now - BirthDate).TotalDays;
        return (Maxlife) - (Life());
    }
    public override double killpriority()
    {
        int Maxlife = 4380;
        double Zarib = (TimeToDie()) / (Maxlife);
        if (IsShrdeh == true)
            return Zarib + 0 / 3;
        else
            return 1 - Zarib;
    }

    
    public override double CostPerDay()
    {
        int GheymateShireKham = 15000;
        return (sp.HealthParameterNumberOfMilkProduction) * (GheymateShireKham);
    }
    SheepParameters sp = new SheepParameters()
    {
        HealthParameterTimeToStand = 90,
        HealthParameterTimeToDeal = 50,
        HealthParameterTimeToRelax = 140,
        HealthParameterNumberOfMeal = 15,
        HealthParameterNumberOfMilkProduction = 12
    };
}
public interface IAnimalEnvironment
{
    public int HealthParameterTDS { get; set; }

    public double HealthParameterTemperature { get; set; }

    public double HealthParameterDensity { get; set; }

    public int HealthParameterDecibel { get; set; }

    public int HealthParameterAQI { get; set; }

    public int HealthParameterOxygen { get; set; }

    public DateTime Date { get; set; }


}

public record class AnimalEnvironment : IAnimalEnvironment
{
    public int HealthParameterTDS { get; set; }

    public double HealthParameterTemperature { get; set; }

    public double HealthParameterDensity { get; set; }

    public int HealthParameterDecibel { get; set; }

    public int HealthParameterAQI { get; set; }

    public int HealthParameterOxygen { get; set; }

    public DateTime Date { get; set; }
    public string Tostring()
    {
        return
        $"TDS:{HealthParameterTDS}...TEMP:{HealthParameterTemperature}...DEN:{HealthParameterDensity}...DB:{HealthParameterDecibel}...AQI:{HealthParameterAQI}....O2:{HealthParameterOxygen}";
    }

}
public class CowParameters
{
    public int HealthParameterTimeToStand { get;set; }
    public int HealthParameterTimeToDeal { get; set; }
    public int HealthParameterTimeToRelax { get; set; }
    public int HealthParameterNumberOfMeal { get;set; }
    public int HealthParameterNumberOfMilkProduction { get; set; }
}
public class SheepParameters
{
    public int HealthParameterTimeToStand { get; set; }
    public int HealthParameterTimeToDeal { get; set; }
    public int HealthParameterTimeToRelax { get; set; }
    public int HealthParameterNumberOfMeal { get; set; }
    public int HealthParameterNumberOfMilkProduction { get; set; }
}