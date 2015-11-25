using System;
using System.Collections.Generic;
using System.Text;

namespace BMSP.DBAccesser.DBScript
{
    public class Pagination
    {
        private int _pageNumber = 1;
        public int PageNumber
        {
            get { return _pageNumber; }
            set { _pageNumber = value; }
        }

        private int _pageSize = 15;
        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public int PageCount
        {
            get
            {
                if (this.Total > 0)
                {
                    if (this.Total % this.PageSize == 0)
                    {
                        return this.Total / this.PageSize;
                    }
                    else
                    {
                        return this.Total / this.PageSize + 1;
                    }
                }
                else
                {
                    return 1;
                }
            }
        }

        private int total;
        public int Total
        {
            set { total = value; }
            get { return total; }
        }
        public int NotSelectedNumber
        {
            get
            {
                return (this.PageNumber - 1) * this.PageSize;
            }
        }
    }
}
