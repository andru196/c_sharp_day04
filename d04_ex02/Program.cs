using System;
using d04_ex02.ConsoleSetter;
using d04_ex02.Models;

var user = new IdentityUser();
ConsoleSetter.SetValues(user);

#if DEBUG
	var role = new IdentityRole();
	ConsoleSetter.SetValues(role);
#endif