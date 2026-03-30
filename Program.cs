

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ARRAYS 
            string[] patientNames = new string[100];
            string[] patientIDs = new string[100];
            string[] diagnoses = new string[100];
            bool[] admitted = new bool[100];
            string[] assignedDoctors = new string[100];
            string[] departments = new string[100];
            int[] visitCount = new int[100];
            double[] billingAmount = new double[100];

            int lastPatientIndex = -1;

            // SEED DATA 
            lastPatientIndex++;

            patientNames[lastPatientIndex] = "Ali Hassan";
            patientIDs[lastPatientIndex] = "P001";
            diagnoses[lastPatientIndex] = "Flu";
            departments[lastPatientIndex] = "General";
            admitted[lastPatientIndex] = false;
            assignedDoctors[lastPatientIndex] = "";
            visitCount[lastPatientIndex] = 2;
            billingAmount[lastPatientIndex] = 0;

            lastPatientIndex++;

            patientNames[lastPatientIndex] = "Hiba juma";
            patientIDs[lastPatientIndex] = "P002";
            diagnoses[lastPatientIndex] = "Fracture";
            departments[lastPatientIndex] = "Orthopedics";
            admitted[lastPatientIndex] = true;
            assignedDoctors[lastPatientIndex] = "Dr. Noor";
            visitCount[lastPatientIndex] = 4;
            billingAmount[lastPatientIndex] = 0;

            lastPatientIndex++;

            patientNames[lastPatientIndex] = "Saif Saleh";
            patientIDs[lastPatientIndex] = "P003";
            diagnoses[lastPatientIndex] = "Diabetes";
            departments[lastPatientIndex] = "Cardiology";
            admitted[lastPatientIndex] = false;
            assignedDoctors[lastPatientIndex] = "";
            visitCount[lastPatientIndex] = 1;
            billingAmount[lastPatientIndex] = 0;

            //  MENU 
            while (true)
            {
                Console.WriteLine("\n Healthcare System ");
                Console.WriteLine("1. Register New Patient");
                Console.WriteLine("2. Admit Patient");
                Console.WriteLine("3. Discharge Patient");
                Console.WriteLine("4. Search Patient");
                Console.WriteLine("5. List All Admitted Patients");
                Console.WriteLine("6. Transfer Patient");
                Console.WriteLine("7. Most Visited Patients");
                Console.WriteLine("8. Search by Department");
                Console.WriteLine("9. Billing Report");
                Console.WriteLine("10. Exit");

                int choice = int.Parse(Console.ReadLine());

                //  SWITCH
                switch (choice)
                {
                    // 1️ REGISTER
                    case 1:
                        lastPatientIndex++;

                        Console.Write("Name: ");
                        patientNames[lastPatientIndex] = Console.ReadLine();

                        Console.Write("ID: ");
                        patientIDs[lastPatientIndex] = Console.ReadLine();

                        Console.Write("Diagnosis: ");
                        diagnoses[lastPatientIndex] = Console.ReadLine();

                        Console.Write("Department: ");
                        departments[lastPatientIndex] = Console.ReadLine();

                        admitted[lastPatientIndex] = false;
                        assignedDoctors[lastPatientIndex] = "";
                        visitCount[lastPatientIndex] = 0;
                        billingAmount[lastPatientIndex] = 0;

                        Console.WriteLine("Patient registered successfully!");
                        break;

                    // 2️ ADMIT
                    case 2:
                        Console.Write("Enter ID or Name: ");
                        string search = Console.ReadLine();

                        int index = -1;
                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (patientIDs[i] == search || patientNames[i] == search)
                            {
                                index = i;
                                break;
                            }
                        }

                        if (index == -1)
                        {
                            Console.WriteLine("Patient not found");
                        }
                        else if (admitted[index])
                        {
                            Console.WriteLine("Already admitted under " + assignedDoctors[index]);
                        }
                        else
                        {
                            Console.Write("Doctor Name: ");
                            assignedDoctors[index] = Console.ReadLine();

                            admitted[index] = true;
                            visitCount[index]++;

                            Console.WriteLine("Admitted successfully");
                            Console.WriteLine("Admitted " + visitCount[index] + " times");
                        }
                        break;

                    // 3️ DISCHARGE
                    case 3:
                        Console.Write("Enter ID or Name: ");
                        search = Console.ReadLine();

                        index = -1;
                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (patientIDs[i] == search || patientNames[i] == search)
                            {
                                index = i;
                                break;
                            }
                        }

                        if (index == -1)
                        {
                            Console.WriteLine("Patient not found");
                        }
                        else if (!admitted[index])
                        {
                            Console.WriteLine("Not currently admitted");
                        }
                        else
                        {
                            double total = 0;

                            Console.Write("Consultation fee? (yes/no): ");
                            if (Console.ReadLine().ToLower() == "yes")
                            {
                                double fee = double.Parse(Console.ReadLine());
                                total += fee;
                            }

                            Console.Write("Medication charges? (yes/no): ");
                            if (Console.ReadLine().ToLower() == "yes")
                            {
                                double med = double.Parse(Console.ReadLine());
                                total += med;
                            }

                            billingAmount[index] += total;

                            admitted[index] = false;
                            assignedDoctors[index] = "";

                            Console.WriteLine("Total added: " + total + " OMR");
                            Console.WriteLine("Discharged successfully");
                        }
                        break;

                    // 4️ SEARCH
                    case 4:
                        Console.Write("Enter ID or Name: ");
                        search = Console.ReadLine();

                        index = -1;
                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (patientIDs[i] == search || patientNames[i] == search)
                            {
                                index = i;
                                break;
                            }
                        }

                        if (index == -1)
                        {
                            Console.WriteLine("Not found");
                        }
                        else
                        {
                            Console.WriteLine(patientNames[index]);
                            Console.WriteLine(patientIDs[index]);
                            Console.WriteLine(diagnoses[index]);
                            Console.WriteLine(departments[index]);
                            Console.WriteLine("Visits: " + visitCount[index]);
                            Console.WriteLine("Billing: " + billingAmount[index]);

                            if (admitted[index])
                                Console.WriteLine("Doctor: " + assignedDoctors[index]);
                        }
                        break;

                    // 5️ LIST ADMITTED
                    case 5:
                        bool found = false;

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (admitted[i])
                            {
                                found = true;
                                Console.WriteLine(patientNames[i] + " - " + assignedDoctors[i]);
                            }
                        }

                        if (!found)
                            Console.WriteLine("No patients admitted");
                        break;

                    // 6️ TRANSFER
                    case 6:
                        Console.Write("Current Doctor: ");
                        string current = Console.ReadLine();

                        Console.Write("New Doctor: ");
                        string newDoc = Console.ReadLine();

                        bool transferred = false;

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (assignedDoctors[i] == current && admitted[i])
                            {
                                assignedDoctors[i] = newDoc;
                                Console.WriteLine("Transferred " + patientNames[i]);
                                transferred = true;
                                break;
                            }
                        }

                        if (!transferred)
                            Console.WriteLine("No patient found");
                        break;

                    // 7️ SORT VISITS
                    case 7:
                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            for (int j = i + 1; j <= lastPatientIndex; j++)
                            {
                                if (visitCount[j] > visitCount[i])
                                {
                                    // swap
                                    (visitCount[i], visitCount[j]) = (visitCount[j], visitCount[i]);
                                    (patientNames[i], patientNames[j]) = (patientNames[j], patientNames[i]);
                                    (patientIDs[i], patientIDs[j]) = (patientIDs[j], patientIDs[i]);
                                    (diagnoses[i], diagnoses[j]) = (diagnoses[j], diagnoses[i]);
                                    (departments[i], departments[j]) = (departments[j], departments[i]);
                                }
                            }
                        }

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            Console.WriteLine(patientNames[i] + " - " + visitCount[i]);
                        }
                        break;

                    // 8️ SEARCH DEPARTMENT
                    case 8:
                        Console.Write("Department: ");
                        string dept = Console.ReadLine().ToLower();

                        bool deptFound = false;

                        for (int i = 0; i <= lastPatientIndex; i++)
                        {
                            if (departments[i].ToLower() == dept)
                            {
                                deptFound = true;
                                Console.WriteLine(patientNames[i] + " - " +
                                    (admitted[i] ? "Admitted" : "Not Admitted"));
                            }
                        }

                        if (!deptFound)
                            Console.WriteLine("No patients found");
                        break;

                    // 9️ BILLING
                    case 9:
                        Console.WriteLine("1. Total System");
                        Console.WriteLine("2. Individual");

                        int opt = int.Parse(Console.ReadLine());

                        if (opt == 1)
                        {
                            double sum = 0;
                            for (int i = 0; i <= lastPatientIndex; i++)
                                sum += billingAmount[i];

                            Console.WriteLine("Total: " + sum + " OMR");
                        }
                        else
                        {
                            Console.Write("Enter ID or Name: ");
                            search = Console.ReadLine();

                            index = -1;
                            for (int i = 0; i <= lastPatientIndex; i++)
                            {
                                if (patientIDs[i] == search || patientNames[i] == search)
                                {
                                    index = i;
                                    break;
                                }
                            }

                            if (index == -1)
                                Console.WriteLine("No record");
                            else
                                Console.WriteLine("Billing: " + billingAmount[index]);
                        }
                        break;
                    //10 EXIT

                    case 10:
                        Console.WriteLine("Exiting system...");
                        Console.WriteLine("Thank you!");
                        break;

                    default:
                        break;
                }




                Console.WriteLine("press any key");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}