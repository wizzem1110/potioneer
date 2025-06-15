using FluentAssertions;
using NUnit.Framework;

namespace MonoGamePotioneer;

public static class Tests
{
    [Test]
    public static void Test()
    {
        var a = 0;
        a.Should().Be(0);
    }

    [Test]
    public static void ItemCtorTest()
    {
        const string str = "-1 Item 0 None";
        var ing1 = new Item();
        var ing2 = new Item(str);
        var ing3 = new Item(-1, "Item", 0, Type.None);
        ing1.Should().BeEquivalentTo(ing2);
        ing1.Should().BeEquivalentTo(ing3);
        ing2.Should().BeEquivalentTo(ing3);
    }

    [Test]
    public static void ReadDataTest()
    {
        var path = "test.txt";
        var game = new Game(path);
        game.Data.Count.Should().Be(1);
        game.Data[0].Should().BeEquivalentTo(new Item("100 none 0 none"));
    }

    [Test]
    public static void RecipesTest()
    {
        var book = new RecipeBook();
        book.Make((1, 2)).Should().Be(5);
        book.Make((1, 3)).Should().Be(6);
        book.Make((1, 4)).Should().Be(7);
    }
}