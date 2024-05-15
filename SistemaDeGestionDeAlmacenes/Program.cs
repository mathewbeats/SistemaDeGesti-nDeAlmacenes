﻿using System;
using SistemaDeGestionDeAlmacenesAPI;


const int Batch_Size = 5;



//Coleccion de Items de el almacen, taladro, martillo, escalera y pincel

CustomQueue<HardWareItem> hardwareItemQueue = new CustomQueue<HardWareItem>();

hardwareItemQueue.CustomQueueEvent += CustomQueue_CustomQueueEvent;

Thread.Sleep(2000);

//comes into stock - device scans a bar code or QR code
hardwareItemQueue.AddItem(new Drill { Id = 1, Name = "Drill 1", Type = "Drill", UnitValue = 20.00m, Quantity = 10 });

Thread.Sleep(1000);

hardwareItemQueue.AddItem(new Drill { Id = 2, Name = "Drill 2", Type = "Drill", UnitValue = 30.00m, Quantity = 20 });

Thread.Sleep(2000);

hardwareItemQueue.AddItem(new Ladder { Id = 3, Name = "Ladder 1", Type = "Ladder", UnitValue = 100.00m, Quantity = 5 });

Thread.Sleep(1000);

hardwareItemQueue.AddItem(new Hammer { Id = 4, Name = "Hammer 1", Type = "Hammer", UnitValue = 10.00m, Quantity = 80 });
Thread.Sleep(3000);

hardwareItemQueue.AddItem(new PaintBrush { Id = 5, Name = "Paint Brush 1", Type = "PaintBrush", UnitValue = 5.00m, Quantity = 100 });
Thread.Sleep(3000);

hardwareItemQueue.AddItem(new PaintBrush { Id = 6, Name = "Paint Brush 2", Type = "PaintBrush", UnitValue = 5.00m, Quantity = 100 });
Thread.Sleep(3000);

hardwareItemQueue.AddItem(new PaintBrush { Id = 7, Name = "Paint Brush 3", Type = "PaintBrush", UnitValue = 5.00m, Quantity = 100 });
Thread.Sleep(3000);

hardwareItemQueue.AddItem(new Hammer { Id = 8, Name = "Hammer 2", Type = "Hammer", UnitValue = 11.00m, Quantity = 80 });
Thread.Sleep(3000);

hardwareItemQueue.AddItem(new Hammer { Id = 9, Name = "Hammer 3", Type = "Hammer", UnitValue = 13.00m, Quantity = 80 });
Thread.Sleep(3000);

hardwareItemQueue.AddItem(new Hammer { Id = 10, Name = "Hammer 4", Type = "Hammer", UnitValue = 14.00m, Quantity = 80 });
Thread.Sleep(3000);

Console.ReadKey();

static void ProcessItems(CustomQueue<HardWareItem> customQueue)
{

    while (customQueue.QueueLength > 0)
    {
        Thread.Sleep(3000);

        HardWareItem hardWareItem = customQueue.GetItem();
    }
}


static void CustomQueue_CustomQueueEvent(CustomQueue<HardWareItem> sender, QueueEventArgs eventArgs)
{

    Console.Clear();

    Console.WriteLine(MainHeading());
    Console.WriteLine();
    Console.WriteLine(RealTimeUpdateHeading());

    if (sender.QueueLength > 0)
    {
        Console.WriteLine(eventArgs.Message);
        Console.WriteLine();
        Console.WriteLine();

        Console.WriteLine(ItemsInQueueHeading());

        Console.WriteLine(FieldHeadings());

        WriteValuesInQueueToScreen(sender);
        if (sender.QueueLength == Batch_Size)
        {
            ProcessItems(sender);
        }

    }
    else
    {
        Console.WriteLine("All Items Has Been Processed");
    }
}

static void WriteValuesInQueueToScreen(CustomQueue<HardWareItem> hardwareItems)
{
    foreach (var hardwareItem in hardwareItems)
    {
        Console.WriteLine($"{hardwareItem.Id,-6}{hardwareItem.Name,-15}{hardwareItem.Type,-20}{hardwareItem.Quantity,10}{hardwareItem.UnitValue,10}");
    }
}


//Headings
static string FieldHeadings()
{
    return UnderLine($"{"Id",-6}{"Name",-15}{"Type",-20}{"Quantity",10}{"Value",10}");
}

static string RealTimeUpdateHeading()
{
    return UnderLine("Real-time Update");
}

static string ItemsInQueueHeading()
{
    return UnderLine("Items Queued for Processing");
}

static string MainHeading()
{
    return UnderLine("Warehouse Management System");
}

static string UnderLine(string heading)
{
    return $"{heading}{Environment.NewLine}{new string('-', heading.Length)}";
}
//Headings



public abstract class HardWareItem : IEntityPrimaryProperties, IEntityAditionalProperties
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int Quantity { get; set; }
    public decimal UnitValue { get; set; }
}

public interface IDrill
{

    string DrillBrandName { get; set; }

}

public interface ILadder
{

    string LadderBrandName { get; set; }

}

public interface IPaintBrush
{

    string PaintBrushBrandName { get; set; }

}

public interface IHammer
{

    string HammerBrandName { get; set; }

}

public class Drill : HardWareItem, IDrill
{
    public string DrillBrandName { get; set; }

}

public class Ladder : HardWareItem, ILadder
{
    public string LadderBrandName { get; set; }

}

public class PaintBrush : HardWareItem, IPaintBrush
{

    public string PaintBrushBrandName { get; set; }

}

public class Hammer : HardWareItem, IHammer
{
    public string HammerBrandName { get; set; }


}




