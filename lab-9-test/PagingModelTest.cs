using lab_9.Models;
using Xunit;
using Assert = Xunit.Assert;


namespace lab_9_test;

public class PagingModelTest
{
    [Fact]
    public void PagingModelCreateTest()
    {
        PagingList<string> page = PagingList<string>.Create(new List<string>() {"Adam", "Ewa", "Karol"}, 20, 2, 3);
        Assert.Equal(7, page.TotalPages);
    }

    [Fact]
    public void PagingListNextPreviousTest()
    {
        //not last and not first page
        PagingList<string> page = PagingList<string>.Create(new List<string>() {"Adam", "Ewa", "Karol"}, 20, 2, 3);
        Assert.Equal(7, page.TotalPages);
        Assert.False(page.IsFirst);
        Assert.False(page.IsLast);
        Assert.True(page.IsPrevious);
        Assert.True(page.IsNext);
        //last page
        page = PagingList<string>.Create(new List<string>() {"Adam", "Ewa", "Karol"}, 20, 7, 3);
        Assert.False(page.IsFirst);
        Assert.False(page.IsNext);
        Assert.True(page.IsPrevious);
        Assert.True(page.IsLast);
        //first page
        page = PagingList<string>.Create(new List<string>() {"Adam", "Ewa", "Karol"}, 20, 1, 3);
        Assert.True(page.IsFirst);
        Assert.False(page.IsLast);
        Assert.False(page.IsPrevious);
        Assert.True(page.IsNext);
    }
}