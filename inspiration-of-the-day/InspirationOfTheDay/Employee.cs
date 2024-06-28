namespace InspirationOfTheDay;

public class Employee
{
    private readonly string _telephone;

    public Employee(string telephone)
    {
        _telephone = telephone;
    }

    public ContactData GetContactData()
    {
        return new ContactData(_telephone);
    }
}