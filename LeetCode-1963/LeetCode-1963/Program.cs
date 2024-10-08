using System;
using Xunit;

runTests();

// Make sure to add tests here.
void runTests()
{
	//Assert.Equal("expected", "actual");
	Assert.Equal(0, MinSwaps("[]"));
	Assert.Equal(1, MinSwaps("]["));
	Assert.Equal(1, MinSwaps("][]["));
	Assert.Equal(1, MinSwaps("]][["));
	Assert.Equal(2, MinSwaps("]]][[["));
}


int MinSwaps(string s)
{
	int ptr1 = 0;
	int ptr2 = s.Length - 1;

	int openBraces = 0;
	int swapsRequired = 0;

	char[] chars = s.ToCharArray();
	while (ptr1 < ptr2)
	{
		// Open braces simply get added to the "stack".
		if (chars[ptr1] == '[')
		{
			openBraces++;
			ptr1++;
			continue;
		}

		// When the "stack" isn't empty, closed braces simply pop a brace off the "stack".
		if (openBraces > 0)
		{
			openBraces--;
			ptr1++;
			continue;
		}

		// If there are no open braces, then ptr2 is used to find the last open brace so we can swap it with the current closed brace.
		if (chars[ptr2] != '[')
		{
			ptr2--;
			continue;
		}

		// Swap braces once we can. ptr2 can be decremented immediately to be slightly more efficient.
		chars[ptr1] = '[';
		chars[ptr2--] = ']';
		swapsRequired++;
	}

	return swapsRequired;
}