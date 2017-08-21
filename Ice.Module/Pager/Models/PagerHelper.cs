using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pager.Models
{
    public static class PagerHelper
    {
        public static List<T> ToPagerList<T>(this IQueryable<T> allItems, int pageIndex, int pageSize)
        {
            if (pageIndex < 1)
                pageIndex = 1;
            var itemIndex = (pageIndex - 1) * pageSize;
            var totalItemCount = allItems.Count();
            while (totalItemCount <= itemIndex && pageIndex > 1)
            {
                itemIndex = (--pageIndex - 1) * pageSize;
            }
            var pageOfItems = allItems.Skip(itemIndex).Take(pageSize);
            return new PagerList<T>(pageOfItems, pageIndex, pageSize, totalItemCount);
        }
        public static PagerList<T> ToPagerList<T>(this IEnumerable<T> allItems,int pageIndex,int pageSize)
        {

            return allItems.AsEnumerable().ToPagerList(pageIndex,pageSize);
        }
    }
    public interface IPagerList : IEnumerable
    {
        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/IPagedList/Property[@name="CurrentPageIndex"]/*'/>
        int CurrentPageIndex { get; set; }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/IPagedList/Property[@name="PageSize"]/*'/>
        int PageSize { get; set; }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/IPagedList/Property[@name="TotalItemCount"]/*'/>
        int TotalItemCount { get; set; }
    }
    public interface IPagerList<T> : IEnumerable<T>, IPagerList { }
    public class PagerList<T> : List<T>, IPagerList<T>
    {
        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/PagedList/Constructor[@name="PagedList1"]/*'/>
        public PagerList(IEnumerable<T> allItems, int pageIndex, int pageSize)
        {
            PageSize = pageSize;
            var items = allItems as IList<T> ?? allItems.ToList();
            TotalItemCount = items.Count();
            CurrentPageIndex = pageIndex;
            AddRange(items.Skip(StartItemIndex - 1).Take(pageSize));
        }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/PagedList/Constructor[@name="PagedList2"]/*'/>
        public PagerList(IEnumerable<T> currentPageItems, int pageIndex, int pageSize, int totalItemCount)
        {
            AddRange(currentPageItems);
            TotalItemCount = totalItemCount;
            CurrentPageIndex = pageIndex;
            PageSize = pageSize;
        }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/PagedList/Constructor[@name="PagedList3"]/*'/>
        public PagerList(IQueryable<T> allItems, int pageIndex, int pageSize)
        {
            int startIndex = (pageIndex - 1) * pageSize;
            AddRange(allItems.Skip(startIndex).Take(pageSize));
            TotalItemCount = allItems.Count();
            CurrentPageIndex = pageIndex;
            PageSize = pageSize;
        }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/PagedList/Constructor[@name="PagedList4"]/*'/>
        public PagerList(IQueryable<T> currentPageItems, int pageIndex, int pageSize, int totalItemCount)
        {
            AddRange(currentPageItems);
            TotalItemCount = totalItemCount;
            CurrentPageIndex = pageIndex;
            PageSize = pageSize;
        }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/PagedList/Property[@name="CurrentPageIndex"]/*'/>
        public int CurrentPageIndex { get; set; }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/PagedList/Property[@name="PageSize"]/*'/>
        public int PageSize { get; set; }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/PagedList/Property[@name="TotalItemCount"]/*'/>
        public int TotalItemCount { get; set; }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/PagedList/Property[@name="TotalPageCount"]/*'/>
        public int TotalPageCount { get { return (int)Math.Ceiling(TotalItemCount / (double)PageSize); } }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/PagedList/Property[@name="StartItemIndex"]/*'/>
        public int StartItemIndex { get { return (CurrentPageIndex - 1) * PageSize + 1; } }

        ///<include file='MvcPagerDocs.xml' path='MvcPagerDocs/PagedList/Property[@name="EndItemIndex"]/*'/>
        public int EndItemIndex { get { return TotalItemCount > CurrentPageIndex * PageSize ? CurrentPageIndex * PageSize : TotalItemCount; } }
    }
}