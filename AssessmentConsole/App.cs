using System;
using System.Collections.Generic;
using System.Linq;
using Assessment;

namespace AssessmentConsole
{
    public class App
    {
        public bool ProcessOption(string option) 
        {
            if (option == "1")
            {
                StartPagination();
                return false;
            }
            return true;
        }

        private void StartPagination()
        {
            string option = GetOption(
                @"Pagination commands\n
                1. Source data
                0. Back
                ");
             if (option == "1")
            {
                ProcessPagination();
            }
        }

        private void ProcessPagination()
        {
            string option = GetOption(
                @"Type: \n
                1. Comma separated data(,)
                2. Pipe separated data(|)
                3. Space separated data( )
                0. Go Back
                ");
            if (option == "1" || option == "2" || option == "3") 
            {
                string data = GetOption("Source data");
                NavigateData(data, option);
            } 
        }

        private void NavigateData(string data, string option)
        {
            string pageSize = GetOption("Type the Page size");
            IElementsProvider<string> provider = new StringProvider();
            IPagination<string> pagination = new PaginationString(data, int.Parse(pageSize), provider);
            SortData(pagination);
            DoNavigation(pagination);
        }

        private void SortData(IPagination<string> pagination)
        {
            string option = GetOption("Select the way to sort the data \n" +
                "1. Ascendent sort\n" +
                "2. Descendent sort");
            if (option == "1")
            {
                pagination.SortAsc();
            }
            else
            {
                pagination.SortDsc();
            }
            
        }

        private void DoNavigation(IPagination<string> pagination)
        {
            bool exit = false;
            while(!exit)
            {
                Console.WriteLine("Current Page:" + ImpressPage(pagination.GetVisibleItems()));
                 string option = GetOption(
                @"Type: \n
                1. First page
                2. Next page
                3. Previous page
                4. Last page
                5. Go to page
                0. Go Back
                ");                                
                switch (option) 
                {
                    case "1":
                        pagination.FirstPage();
                        break;
                    case "2":
                        pagination.NextPage();
                        break;
                    case "3":
                        pagination.PrevPage();
                        break;
                    case "4":                        
                        pagination.LastPage();
                        break;
                    case "5":
                        int page = Int32.Parse(GetOption("Please enter page index"));
                        pagination.GoToPage(page);
                        break;
                    case "0":
                        exit = false;
                        break;
                }
            }
    
        }

        private string ImpressPage(IEnumerable<string> enumerable)
        {
            string res = "";
            foreach(var element in enumerable)
            {
                res += element + ", ";
            }
            return res;
        }

        private string GetOption(string message)
        {
            Console.WriteLine(message);
            Console.Write("> ");
            return Console.ReadLine();
        }
    }
}