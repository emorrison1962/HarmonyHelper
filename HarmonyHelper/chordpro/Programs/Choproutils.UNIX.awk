These are two utilities for handling ChordPro files.
both are awk scripts. UN*X AWK is available (as GAWK)
from the GNUish project for most platforms. They're
fairly simple though, and easily put into BASIC.

cpstrip		removes chord references from
a chopro file to leave just lyrics.
Usage:
awk -f cpstrip something.chopro


cpascii		places chords above words, taking
input from a chopro file and outputtng ASCII
(plain text) not PostScript.
Usage:
awk -f cpascii something.chopro

These programs are released into the public domain.

Baz.

------ cut here (cpstrip)------
BEGIN { FS="]" } 
{ 	for(i=1;i<=NF;i++)
	{
		for(j=1;j<=length($i)&&substr($i,j,1)!="[";j++)
		{
			printf("%s",substr($i,j,1))
		}
	}
	printf("\n")
}

------- cut here (cpascii)------
BEGIN { FS="]" } 
{ 
	k=1
	for(i=1;i<=NF;i++)
	{
		for(j=k;j<=length($i)&&substr($i,j,1)!="[";j++)
		{
			printf(" ")
		}
		k=1
		for(j++;j<=length($i);j++)
		{
			k++
			printf("%s",substr($i,j,1))
		}
	}
	printf("\n")
	for(i=1;i<=NF;i++)
	{
		for(j=1;j<=length($i)&&substr($i,j,1)!="[";j++)
		{
			printf("%s",substr($i,j,1))
		}
	}
	printf("\n")
}
