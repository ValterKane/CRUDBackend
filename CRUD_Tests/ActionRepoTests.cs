using CRUD.DAL.Context;
using CRUD.DAL.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Action = CRUD.DAL.Entities.Action;

namespace CRUD_Tests;

public class ActionRepoTests
{
    [Fact]
    public void CreateTest_LastItemShouldBeEqualANewItem()
    {
        // Arrange
        var option = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase("Create_Test").Options;

        using var context = new MyDbContext(option);

        var repository = new ActionRepository(context);

        Action inMemAction = new()
        {
            Actuuid = Guid.NewGuid(), Name = "Contained Action", Schedule = "{}", Typeid = 1
        };

        context.Actions.Add(inMemAction);
        context.SaveChanges();

        var currentCount = context.Actions.Count();

        // Act
        var actuuid = Guid.NewGuid();
        repository.Add(new Action() { Actuuid = actuuid, Name = "Inserted Action", Schedule = "{}", Typeid = 1 });

        // Assert
        Assert.NotNull(context.Actions.Last());
        Assert.Equal(context.Actions.Last().Actuuid, actuuid);
    }

    [Fact]
    public void DeleteTest_CountsInContextShouldBeChange()
    {
        // Arrange
        var option = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase("Delete_Test").Options;

        using var context = new MyDbContext(option);

        context.Actions.AddRange(new[]
        {
            new Action() { Actuuid = Guid.NewGuid(), Name = "TestName_1", Schedule = "{}", Typeid = 1 }
            , new Action() { Actuuid = Guid.NewGuid(), Name = "TestName_2", Schedule = "{}", Typeid = 1 }
            , new Action() { Actuuid = Guid.NewGuid(), Name = "TestName_3", Schedule = "{}", Typeid = 1 }
        });

        context.SaveChanges();

        var itemToDelete = context.Actions.Last();

        var countItemInContext = context.Actions.Count();

        var repository = new ActionRepository(context);

        // Act
        repository.Delete(itemToDelete);
        var newCountItemInContext = context.Actions.Count();

        //Assert
        Assert.True(countItemInContext != 0);
        Assert.Equal(countItemInContext - 1, newCountItemInContext);
    }

    [Fact]
    public void ReadTest_NumberOfInsertedAndReadItemsShouldBeEqual()
    {
        // Arrange
        var option = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase("Read_Test").Options;

        using var context = new MyDbContext(option);

        context.Actions.AddRange(new[]
        {
            new Action() { Actuuid = Guid.NewGuid(), Name = "TestName_1", Schedule = "{}", Typeid = 1 }
            , new Action() { Actuuid = Guid.NewGuid(), Name = "TestName_2", Schedule = "{}", Typeid = 1 }
            , new Action() { Actuuid = Guid.NewGuid(), Name = "TestName_3", Schedule = "{}", Typeid = 1 }
        });

        context.SaveChanges();

        var oldCount = context.Actions.Count();

        var repository = new ActionRepository(context);

        // Act
        var readedData = repository.GetAll().ToList() ?? [];
        var newCount = readedData.Count;

        // Assert
        Assert.True(newCount != 0);
        Assert.Equal(oldCount, newCount);
    }

    [Fact]
    public void UpdateTest_NameOfFirstItemShouldBeChanging()
    {
        // Arrange
        var option = new DbContextOptionsBuilder<MyDbContext>()
            .UseInMemoryDatabase("Update_Test").Options;

        using var context = new MyDbContext(option);


        context.Actions.AddRange(new[]
        {
            new Action() { Actuuid = Guid.NewGuid(), Name = "TestName_1", Schedule = "{}", Typeid = 1 }
            , new Action() { Actuuid = Guid.NewGuid(), Name = "TestName_2", Schedule = "{}", Typeid = 1 }
            , new Action() { Actuuid = Guid.NewGuid(), Name = "TestName_3", Schedule = "{}", Typeid = 1 }
        });

        context.SaveChanges();

        var repository = new ActionRepository(context);

        // Act
        var newName = "UpdatedActionName";
        var targetItem = context.Actions.FirstOrDefault();
        targetItem!.Name = newName;
        repository.Update(targetItem);

        //Assert
        Assert.Equal(context.Actions.First().Name, newName);
    }

    [Fact]
    public async void ReadAsyncTest_NumberOfInsertedAndReadItemsShouldBeEqual()
    {
        // Arrange
        var option = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase("ReadAsyncTest").Options;

        await using var context = new MyDbContext(option);

        context.Actions.AddRange(new[]
        {
            new Action() { Actuuid = Guid.NewGuid(), Name = "TestName_1", Schedule = "{}", Typeid = 1 }
            , new Action() { Actuuid = Guid.NewGuid(), Name = "TestName_2", Schedule = "{}", Typeid = 1 }
            , new Action() { Actuuid = Guid.NewGuid(), Name = "TestName_3", Schedule = "{}", Typeid = 1 }
        });

        await context.SaveChangesAsync();

        var oldCount = await context.Actions.CountAsync();

        var repository = new ActionRepository(context);

        // Act
        var items = (await repository.GetAllAsync()).ToList();
        var newCount = items.Count;

        //Assert
        Assert.Equal(oldCount, newCount);
    }

    [Fact]
    public async void CreateAsyncTest_ContextDataShouldNotBeEmpty()
    {
        // Arrange
        var option = new DbContextOptionsBuilder<MyDbContext>().UseInMemoryDatabase("CreateAsyncTest").Options;

        await using var context = new MyDbContext(option);

        var oldCount = await context.Actions.CountAsync();

        var repository = new ActionRepository(context);
        
        // Act
        await repository.AddAsync(new Action() { Actuuid = Guid.NewGuid(), Name = "NewItem", Schedule = "{}", Typeid = 1
        });

        // Assert
        Assert.NotEmpty(context.Actions);

    }
}
