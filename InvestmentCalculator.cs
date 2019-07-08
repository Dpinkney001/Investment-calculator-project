using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

// Duvall pinkney  7/5/2015 version 1
// version 2.0 7/19/2015
//version 3.0 9/14/2015
// Version 4.0 2/12/2019 C# conversion
// program to analyize users target goal to save for investment and outputs the amount each  (months, years)
// needed to reach that target goal.


namespace Target_Investment_calculator_version_4
{
    static class InvestmentCalculator
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        private void inputTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // if user pressed enter key
            if (e.KeyCode == Keys.Enter)
            {
                // create a filename to write to file
                string fileName = inputTextBox_KeyDown.Text;

                // determine whether fileName is a file
                if (FileDialog.Exists(fileName))
                {
                    // get files creation date, modification date etc
                    GetInformation(fileName);
                    StreamReader stream = null; // declare StreamReader
                    try
                    {
                        // obtain reader and file contents
                        using (stream = new StreamReader(fileName))
                        {
                            outputTextBox.AppendText(stream.ReadToEnd());
                        }// end using
                    }// end try
                    catch (IOException)
                    {
                        MessageBox.Show("Error reading from file", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }// end catch
                }// end if
                // determine whether fileName is a directory
                else if (Directory.Exists(fileName))
                {
                    // get directory's creations date,
                    // modification date, etc
                    GetInformation(fileName);


                    //obtain directory list of specified directory
                    string[] directoryList = Directory.GetDirectories(fileName);

                    outputTextBox.AppendText("Directory contents:\n");

                    // output directoryList contents
                    foreach (var directory in directoryList)
                        outputTextBox.AppendText("Directory contents:\n");
                } // end else if
                else
                {
                    // notify user that neither file nor directory exists
                    MessageBox.Show(inputTextBox_KeyDown.Text + " does not exist", "File Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }// end else
            }// end if
        }// end method inputTextBox_KeyDown

        // get information on file or directory,
        // and output it to outputTextBox
        private void GetInformation( string fileName )
        {
            outputTextBox.clear();

            outputTextBox.AppendText( fileName + " exist\n" );

            outputTextBox.AppendText("Created: " + FileDialog.GetCreationTime(fileName) + "\n");


        }
                    //

                }
            }
        }

/*

# write outputs into a file investmentCalcReport.txt
#
#
        def outputfile():
    outfile = open("investmentCalcReport.txt", 'w')




# grab input values from the user
        def targetAmountInput():
    targetAmount = eval(input("Please enter the target amount you wish to save to invest: "))
    targetYears = eval(input("Please enter the number of YEARS in which you wish to reach this goal: "))
    targetMonths = eval(input("Please enter the number of MONTHS in which you wish to reach this goal: "))
    # target pay periods aka target ever 2 weeks
    Console.WriteLine("Please enter the target amount you wish to save to invest: ");
    targetAmount = Console.ReadLine()

    targetAmountPerYear = 0.0
    targetAmountPerYear = targetAmount / targetYears
    print("You need to save", targetAmountPerYear," every year to reach your goal")

    months = 0
    months = targetYears* 12
    amountPerMonths = targetAmount / months
    print("or save ", amountPerMonths," for ", months,"month(s).")

    targetAmountPerMonth = 0.0
    targetAmountPerMonth = targetAmount / 12
    print("You need to save", targetAmountPerMonth," every month to reach your goal")
    
    
    return targetAmount, targetYears, targetMonths, months



def Jobs() :
    numOfJobs = eval(input("How many jobs do you work? Enter that number: "))
    jobcounter = 0
    while jobcounter<numOfJobs:
            
        for jobs in range(1,numOfJobs + 1):
            jobs = 1
            monthlyIncomeTotal = 0
            
            print("For job number ", jobs," Do you get paid by the hour or by salary? ")
            kindOfPay = input("Enter SALARY of HOURLY here: ")
            if kindOfPay == "HOURLY":
                # example 17.00 an hour times 40 hours per week
                print("")
                hourlyRate = eval(input("How much do you get paid an hour? Enter that amount: "))
                hoursPerWeek = eval(input("How many hours do you work per week? Enter that amount: "))
                wagesPerWeek = hourlyRate* hoursPerWeek
                wagesPerYear = wagesPerWeek* 52
                # monthly wages
                monthlyWages = hourlyRate* hoursPerWeek * 4
                print("")
                print("your monthly income is $", monthlyWages," before taxes.")
                print("")
                print("your yearly income is $", wagesPerYear," before taxes.")


                jobs + 1
                jobcounter + 1
                monthlyIncomeTotal = monthlyIncomeTotal + monthlyWages

            elif kindOfPay == "hourly":
                # example 17.00 an hour times 40 hours per week
                print("")
                hourlyRate = eval(input("How much do you get paid an hour? Enter that amount: "))
                hoursPerWeek = eval(input("How many hours do you work per week? Enter that amount: "))
                wagesPerWeek = hourlyRate* hoursPerWeek
                wagesPerYear = wagesPerWeek* 52
                # monthly wages
                monthlyWages = hourlyRate* hoursPerWeek * 4
                print("")
                print("your monthly income is $", monthlyWages," before taxes.")
                print("")
                print("your yearly income is $", wagesPerYear," before taxes.")


                jobs + 1
                jobcounter + 1
                monthlyIncomeTotal = monthlyIncomeTotal + monthlyWages


            elif kindOfPay == "SALARY":
                print("")
                salary = eval(input("What is your salary? Enter that amount: "))
                monthlyIncome = salary / 12
                print("your monthly income is $", monthlyIncome)
                biweeklyIncome = monthlyIncome / 2
                print("")
                print("Your biweekly income is $", biweeklyIncome)


                jobs + 1
                jobcounter + 1
                monthlyIncomeTotal = monthlyIncomeTotal + monthlyIncome

            elif kindOfPay == "salary":
                print("")
                salary = eval(input("What is your salary? Enter that amount: "))
                monthlyIncome = salary / 12
                print("your monthly income is $", monthlyIncome)
                biweeklyIncome = monthlyIncome / 2
                print("")
                print("Your biweekly income is $", biweeklyIncome)


                jobs + 1
                jobcounter + 1
                monthlyIncomeTotal = monthlyIncomeTotal + monthlyIncome
                
            else:
                print("Please enter your type of pay. Hourly or salary: ")
                break;
            print("-----------------------------------------------------------")
            print("Your total monthly income is $", monthlyIncomeTotal)
        return monthlyIncomeTotal





def expenses(monthlyIncomeTotal) :
    totalMonthlyCostOfLiving = 0
    lifeexpenses = 0
    while totalMonthlyCostOfLiving != -1:
         totalMonthlyCostOfLiving = eval(input("What is the total cost of living for the month? Enter that amount or -1 to exit: "))
    lifeexpenses = totalMonthlyCostOfLiving + lifeexpenses

    return lifeexpenses

def savings(monthlyIncomeTotal, targetAmount, targetYears, targetMonths) :
    targetSavings = eval(input("What is the target amount you are trying to save for your life savings? Enter the amount: "))
    
    
    savingPerMonth = eval(input("How much are you planning to save for your life savings each month? Enter that amount: "))
    
    lifeSavingsACC = savingPerMonth* targetMonths
    remainingAmount = targetSavings - lifeSavingsACC
    print("At this rate of ", savingPerMonth,"for ", targetMonths,"months, you would have saved ", lifeSavingsACC,".")
    if monthlyIncomeTotal > targetAmount:
        excessAmount = monthlyIncomeTotal - targetAmount
        print("The excess amount is: ", excessAmount)

    elif targetAmount > monthlyIncomeTotal:
        deficitAmount = targetAmount - monthlyIncomeTotal
        print("The amount remaining is: ", deficitAmount)

    elif targetAmount == monthlyIncomeTotal:
        print("Your income and  target amount are equal!")




# function calls for main program
        def main():

    print("This program was written by Duvall Pinkney. This program calculate the amount of time needed to raise target amount of money for investment")
    print("version 3.0")
    print("*************************************************************************************************************************************")

    monthlyIncomeTotal = Jobs()
    targetAmount, targetYears, targetMonths, months = targetAmountInput()
    savings(monthlyIncomeTotal, targetAmount, targetYears, targetMonths)
    expenses(monthlyIncomeTotal)








    print("Amount needed each month is : ", targetAmountPerMonth)
    print("Amount needed each years is : ", targetAmountPerYear)
    #print("Amount needed every 2 weeks is: ",)
   
main()
    }
}
*/