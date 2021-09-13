using System.Collections.Generic;
using System.Linq;

namespace Assessment
{
    public class PaginationString : IPagination<string>
    {
        private readonly List<string> data;
        private readonly int pageSize;
        private int currentPage;

        public PaginationString(string source, int pageSize, IElementsProvider<string> provider)
        {
            data = provider.ProcessData(source).ToList();
            currentPage = 0;
            this.pageSize = pageSize;
        }
        public void FirstPage()
        {
            currentPage = 0;
        }

        public void GoToPage(int page)
        {
            if (currentPage >= page)
            {
                currentPage = page - 1;
            }
        }

        public void LastPage()
        {
            currentPage = pageSize-1;
        }

        public void NextPage()
        {
            currentPage++;
        }

        public void PrevPage()
        {
            currentPage--;
        }

        public IEnumerable<string> GetVisibleItems()
        {
            return data.Skip(currentPage*pageSize).Take(pageSize);
        }

        public int CurrentPage()
        {
            return currentPage;
        }

        public int Pages()
        {
            return pageSize;
        }

        public void SortAsc()
        {
            data.Sort();
        }

        public void SortDsc()
        {
            data.Sort((a, b) => b.CompareTo(a));
        }
    }
}