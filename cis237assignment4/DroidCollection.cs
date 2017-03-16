using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cis237assignment4
{
    //Class Droid Collection implements the IDroidCollection interface.
    //All methods declared in the Interface must be implemented in this class 
    class DroidCollection : IDroidCollection
    {
        //Private variable to hold the collection of droids
        private IDroid[] droidCollection;
        //Private variable to hold the length of the Collection
        private int lengthOfCollection;
        private GenericStack<ProtocolDroid> ProtocolDroidStack = new GenericStack<ProtocolDroid>(); // ***************
        private GenericStack<UtilityDroid> UtilityDroidStack = new GenericStack<UtilityDroid>(); // ***************
        private GenericStack<AstromechDroid> AstromechDroidStack = new GenericStack<AstromechDroid>(); // ***************
        private GenericStack<JanitorDroid> JanitorDroidStack = new GenericStack<JanitorDroid>(); // ***************

        private GenericQueue<Droid> DroidQueue = new GenericQueue<Droid>();

        //Constructor that takes in the size of the collection.
        //It sets the size of the internal array that will be used.
        //It also sets the length of the collection to zero since nothing is added yet.
        public DroidCollection(int sizeOfCollection)
        {
            //Make new array for the collection
            droidCollection = new IDroid[sizeOfCollection];

            //set length of collection to 0
            this.AddHardCoded();
            lengthOfCollection = 16;

        }

        // SORT ORDER IN QUEUE: Astromech, Janitor, Utility, Protocol
        public void SortDroidsByModel()
        {
            for (int i = 0; i < lengthOfCollection; i++)
            {
                if (droidCollection[i] != null)
                {
                    if (droidCollection[i].Model == "Astromech")
                        AstromechDroidStack.AddToFront((AstromechDroid)droidCollection[i]);
                    if (droidCollection[i].Model == "Janitor")
                        JanitorDroidStack.AddToFront((JanitorDroid)droidCollection[i]);
                    if (droidCollection[i].Model == "Utility")
                        UtilityDroidStack.AddToFront((UtilityDroid)droidCollection[i]);
                    if (droidCollection[i].Model == "Protocol")
                        ProtocolDroidStack.AddToFront((ProtocolDroid)droidCollection[i]);
                }
            }

            Console.WriteLine(ProtocolDroidStack.Size);
            Console.WriteLine(UtilityDroidStack.Size);
            Console.WriteLine(AstromechDroidStack.Size);
            Console.WriteLine(JanitorDroidStack.Size);

            while (!AstromechDroidStack.IsEmpty)
            {
                DroidQueue.AddToFront(AstromechDroidStack.RemoveFromBack());
            }
            while (!JanitorDroidStack.IsEmpty)
            {
                DroidQueue.AddToFront(JanitorDroidStack.RemoveFromBack());
            }
            while (!UtilityDroidStack.IsEmpty)
            {
                DroidQueue.AddToFront(UtilityDroidStack.RemoveFromBack());
            }
            while (!ProtocolDroidStack.IsEmpty)
            {
                DroidQueue.AddToFront(ProtocolDroidStack.RemoveFromBack());
            }

            for (int i = 0; i < lengthOfCollection; i++)
            {
                 if (!DroidQueue.IsEmpty)
                     droidCollection[i] = DroidQueue.RemoveFromBack();
            }
        }

        protected void AddHardCoded()
        {
            // Add Protocol droids
            droidCollection[0] = new ProtocolDroid("Carbonite", "Protocol", "Bronze", 3);
            droidCollection[1] = new ProtocolDroid("Vanadium", "Protocol", "Bronze", 4);
            droidCollection[2] = new ProtocolDroid("Quadranium", "Protocol", "Gold", 10);
            droidCollection[3] = new ProtocolDroid("Carbonite", "Protocol", "Silver", 12);
            // Add utility
            droidCollection[4] = new UtilityDroid("Vanadium", "Utility", "Gold", true, false, true);
            droidCollection[5] = new UtilityDroid("Carbonite", "Utility", "Silver", false, true, true);
            droidCollection[6] = new UtilityDroid("Quadranium", "Utility", "Bronze", true, true, true);
            droidCollection[7] = new UtilityDroid("Vanadium", "Utility", "Gold", false, false, false);
            // Add astromech
            droidCollection[8] = new AstromechDroid("Carbonite", "Astromech", "Bronze", false, false, false, true, 4);
            droidCollection[9] = new AstromechDroid("Vanadium", "Astromech", "Bronze", false, false, false, true, 6);
            droidCollection[10] = new AstromechDroid("Carbonite", "Astromech", "Bronze", false, true, false, true, 5);
            droidCollection[11] = new AstromechDroid("Quadranium", "Astromech", "Bronze", true, false, false, true, 12);
            // Add janitorial
            droidCollection[12] = new JanitorDroid("Carbonite", "Janitor", "Gold", false, false, false, true, false);
            droidCollection[13] = new JanitorDroid("Quadranium", "Janitor", "Bronze", true, false, false, true, false);
            droidCollection[14] = new JanitorDroid("Quadranium", "Janitor", "Silver", true, false, true, true, false);
            droidCollection[15] = new JanitorDroid("Carbonite", "Janitor", "Bronze", true, false, false, true, false);
        }

        //The Add method for a Protocol Droid. The parameters passed in match those needed for a protocol droid
        public bool Add(string Material, string Model, string Color, int NumberOfLanguages)
        {
            //If there is room to add the new droid
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                //Add the new droid. Note that the droidCollection is of type IDroid, but the droid being stored is
                //of type Protocol Droid. This is okay because of Polymorphism.
                droidCollection[lengthOfCollection] = new ProtocolDroid(Material, Model, Color, NumberOfLanguages);
                //Increase the length of the collection
                lengthOfCollection++;
                //return that it was successful
                return true;
            }
            //Else, there is no room for the droid
            else
            {
                //Return false
                return false;
            }
        }

        //The Add method for a Utility droid. Code is the same as the above method except for the type of droid being created.
        //The method can be redeclared as Add since it takes different parameters. This is called method overloading.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new UtilityDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Janitor droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasTrashCompactor, bool HasVaccum)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new JanitorDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasTrashCompactor, HasVaccum);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The Add method for a Astromech droid. Code is the same as the above method except for the type of droid being created.
        public bool Add(string Material, string Model, string Color, bool HasToolBox, bool HasComputerConnection, bool HasArm, bool HasFireExtinguisher, int NumberOfShips)
        {
            if (lengthOfCollection < (droidCollection.Length - 1))
            {
                droidCollection[lengthOfCollection] = new AstromechDroid(Material, Model, Color, HasToolBox, HasComputerConnection, HasArm, HasFireExtinguisher, NumberOfShips);
                lengthOfCollection++;
                return true;
            }
            else
            {
                return false;
            }
        }

        //The last method that must be implemented due to implementing the interface.
        //This method iterates through the list of droids and creates a printable string that could
        //be either printed to the screen, or sent to a file.
        public string GetPrintString()
        {
            //Declare the return string
            string returnString = "";

            //For each droid in the droidCollection
            foreach (IDroid droid in droidCollection)
            {
                //If the droid is not null (It might be since the array may not be full)
                if (droid != null)
                {
                    //Calculate the total cost of the droid. Since we are using inheritance and Polymorphism
                    //the program will automatically know which version of CalculateTotalCost it needs to call based
                    //on which particular type it is looking at during the foreach loop.
                    droid.CalculateTotalCost();
                    //Create the string now that the total cost has been calculated
                    returnString += "******************************" + Environment.NewLine;
                    returnString += droid.ToString() + Environment.NewLine + Environment.NewLine;
                    returnString += "Total Cost: " + droid.TotalCost.ToString("C") + Environment.NewLine;
                    returnString += "******************************" + Environment.NewLine;
                    returnString += Environment.NewLine;
                }
            }

            //return the completed string
            return returnString;
        }
    }
}
