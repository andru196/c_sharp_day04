using System;
using d04_ex03.Models;
using d04_ex03;

var typeIR = typeof(IdentityRole);
var typeIU = typeof(IdentityUser);

Console.WriteLine($"{typeIU.Namespace}{typeIU.Name}");
var user1 = TypeFactory.CreateWithConstructor<IdentityUser>();
var user2 = TypeFactory.CreateWithActivator<IdentityUser>();
Console.WriteLine($"user1 {(user1 == user2 ? "==" : "!=")} user2");

Console.WriteLine($"{typeIR.Namespace}{typeIR.Name}");
var role1 = TypeFactory.CreateWithConstructor<IdentityRole>();
var role2 = TypeFactory.CreateWithActivator<IdentityRole>();
Console.WriteLine($"user1 {(role2 == role1 ? "==" : "!=")} user2");

var user3 = TypeFactory.CreateWithParameters<IdentityUser>("Andrew");
Console.WriteLine($"With parameters: {typeIU.Namespace}{typeIU.Name}.UserName = {user3?.UserName}");