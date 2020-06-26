using System.Collections.Generic;
using System.Threading.Tasks;
using ContactsBackendDotnet.Controllers;
using ContactsBackendDotnet.Models;
using Microsoft.AspNetCore.Mvc;
using Xunit;

public class ContactsControllerTest
{
    [Fact]
    public async Task Can_get_all_contactsAsync()
    {
        using var factory = new TestDbContextFactory();
        using var context = await factory.CreateContextAsync();

        context.AddRange(
            new Contact { FirstName = "Albert", LastName = "Einstein", PhoneNumber = "2222-1111" },
            new Contact { FirstName = "Marie", LastName = "Curie", PhoneNumber = "1111-1111" });
        await context.SaveChangesAsync();

        var controller = new ContactsController(null, context);

        var result = await controller.Get();
        var actual = result.Value as IList<Contact>;

        Assert.NotNull(actual);
        Assert.Equal(2, actual.Count);
        Assert.Equal("Albert", actual[0].FirstName);
        Assert.Equal("Marie", actual[1].FirstName);
    }

    [Fact]
    public async Task Can_get_one_contact()
    {
        using var factory = new TestDbContextFactory();
        using var context = await factory.CreateContextAsync();

        var contact = new Contact { FirstName = "Albert", LastName = "Einstein", PhoneNumber = "2222-1111" };
        var expected = contact.Clone();
        context.Add(contact);
        await context.SaveChangesAsync();

        var controller = new ContactsController(null, context);

        var result = await controller.Get(expected.Id);
        var actual = result.Value;

        Assert.NotNull(actual);
        Assert.Equal(expected.FirstName, actual.FirstName);
        Assert.Equal(expected.LastName, actual.LastName);
        Assert.Equal(expected.PhoneNumber, actual.PhoneNumber);
    }


    [Fact]
    public async Task Can_delete_a_contact()
    {
        using var factory = new TestDbContextFactory();
        using var context = await factory.CreateContextAsync();

        var contact = new Contact { FirstName = "Albert", LastName = "Einstein", PhoneNumber = "2222-1111" };
        var expected = contact.Clone();
        await context.AddAsync(contact);
        await context.SaveChangesAsync();

        var controller = new ContactsController(null, context);

        var result = await controller.Delete(expected.Id);

        Assert.IsType<NoContentResult>(result);
        Assert.Empty(context.Contacts);
    }


    [Fact]
    public async Task Can_create_a_contact()
    {
        using var factory = new TestDbContextFactory();
        using var context = await factory.CreateContextAsync();

        var contact = new Contact { FirstName = "Albert", LastName = "Einstein", PhoneNumber = "2222-1111" };
        var expected = contact.Clone();

        var controller = new ContactsController(null, context);

        var result = await controller.Post(contact);

        Assert.IsType<CreatedAtActionResult>(result);
        var createdAtActionResult = result as CreatedAtActionResult;

        var actual = createdAtActionResult.Value as Contact;
        Assert.Equal(expected.FirstName, actual.FirstName);
        Assert.Equal(expected.LastName, actual.LastName);
        Assert.Equal(expected.PhoneNumber, actual.PhoneNumber);

        Assert.Single(context.Contacts, c => c.Id == expected.Id);
    }


    [Fact]
    public async Task Can_update_a_contact()
    {
        using var factory = new TestDbContextFactory();
        using var context = await factory.CreateContextAsync();

        var contact = new Contact { FirstName = "Albert", LastName = "Einstein", PhoneNumber = "2222-1111" };
        await context.AddAsync(contact);
        await context.SaveChangesAsync();

        var changedContact = contact.Clone();
        changedContact.FirstName = "Ulbert";
        changedContact.LastName = "Oinstein";
        changedContact.PhoneNumber = "3333-4444";

        var expected = changedContact.Clone();

        var controller = new ContactsController(null, context);

        var result = await controller.Update(changedContact, changedContact.Id);
        Assert.IsType<NoContentResult>(result);
        Assert.Single(context.Contacts, c => c.Id == changedContact.Id);

        var actual = await context.Contacts.FindAsync(expected.Id);
        Assert.Equal(expected.FirstName, actual.FirstName);
        Assert.Equal(expected.LastName, actual.LastName);
        Assert.Equal(expected.PhoneNumber, actual.PhoneNumber);
    }
}