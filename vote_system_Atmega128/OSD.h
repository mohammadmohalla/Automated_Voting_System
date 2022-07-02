#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <delay.h>
//begin osd//
#define OSD_nCS PORTB.0
#define OSD_nReset Reset
//MAX7456 opcodes
#define DMM_reg   0x04  //Display Memory Mode
#define DMAH_reg  0x05  //Display Memory Address High
#define DMAL_reg  0x06  //Display Memory Address Low
#define DMDI_reg  0x07  //Display Memory Data In

#define VM0_reg   0x00  //Video Mode 0
#define VM1_reg   0x01  //Video Mode 1,
#define CMAH_reg   0x09  //character memory address hi
#define CMAL_reg   0x0A  //character memory address lo
#define CMDI_reg   0x0B  //Character Memory Data In CMM 
#define CMM_reg   0x08  //Character Memory Mode
#define STATUS_READ 0xA0

#define HOR_Offset 0x02
#define VER_Offset 0x03


//MAX7456 commands
#define CLEAR_display 0x04
#define CLEAR_display_vert 0x06
#define END_string 0xff
//// with NTSC
//#define ENABLE_display 0x08
//#define ENABLE_display_vert 0x0c
//#define MAX7456_reset 0x02
//#define DISABLE_display 0x00

// with PAL
// all VM0_reg commands need bit 6 set
#define ENABLE_display 0x48
#define ENABLE_display_vert 0x4c
#define MAX7456_reset 0x42
#define DISABLE_display 0x40

#define WHITE_level_80 0x03
#define WHITE_level_90 0x02
#define WHITE_level_100 0x01
#define WHITE_level_120 0x00
int i; 
unsigned char dash[] = { //////////// " |"
               0xFF,0xFF,0xFF,//1
               0xFF,0xFF,0xFF,//2
               0xAA,0xAA,0xAA,//3
               0xFF,0xFF,0xFF,//4
               0xFF,0xFF,0xFF,//5
               0xFF,0xFF,0xFF,//6
               0xFF,0xFF,0xFF,//7
               0xFF,0xFF,0xFF,//8
               0xFF,0xFF,0xFF,//9
               0xFF,0xFF,0xFF,//10
               0xFF,0xFF,0xFF,//11
               0xFF,0xFF,0xFF,//12
               0xFF,0xFF,0xFF,//13
               0xFF,0xFF,0xFF,//14
               0xFF,0xFF,0xFF,//15
               0xFF,0xFF,0xFF,//16
               0xFF,0xFF,0xFF,//17
               0xFF,0xFF,0xFF,};//18   
unsigned char dash_Ver[] = { //////////// " |"
               0xBF,0xFF,0xFF,//1
               0xBF,0xFF,0xFF,//2
               0xBF,0xFF,0xFF,//3
               0xBF,0xFF,0xFF,//4
               0xBF,0xFF,0xFF,//5
               0xBF,0xFF,0xFF,//6
               0xBF,0xFF,0xFF,//7
               0xBF,0xFF,0xFF,//8
               0xBF,0xFF,0xFF,//9
               0xBF,0xFF,0xFF,//10
               0xBF,0xFF,0xFF,//11
               0xBF,0xFF,0xFF,//12
               0xBF,0xFF,0xFF,//13
               0xBF,0xFF,0xFF,//14
               0xBF,0xFF,0xFF,//15
               0xBF,0xFF,0xFF,//16
               0xBF,0xFF,0xFF,//17
               0xFF,0xFF,0xFF,};//18               
unsigned char star[] = { //////////// " |"
               0xFF,0xFF,0xFF,//1
               0xFF,0xFF,0xFF,//2
               0xFF,0xFF,0xFF,//3
               0xBF,0x28,0xFE,//4
               0xEF,0x28,0xFB,//5
               0xFB,0x28,0xEF,//6
               0xFE,0x28,0xBF,//7
               0xFF,0xAA,0xFF,//8
               0xAA,0xAA,0xAA,//9
               0xAA,0xAA,0xAA,//10
               0xFF,0xAA,0xFF,//11
               0xFE,0x28,0xBF,//12
               0xFB,0x28,0xEF,//13
               0xEF,0x28,0xFB,//14
               0xBF,0x28,0xFE,//15
               0xFF,0xFF,0xFF,//16
               0xFF,0xFF,0xFF,//17
               0xFF,0xFF,0xFF,};//18 
unsigned char sharp[] = { //////////// " |"
               0xFE,0xFF,0xBF,//1
               0xFE,0xFF,0xBF,//2
               0xFE,0xFF,0xBF,//3
               0xFE,0xFF,0xBF,//4
               0xFE,0xFF,0xBF,//5
               0xAA,0xAA,0xAA,//6
               0xFE,0xFF,0xBF,//7
               0xFE,0xFF,0xBF,//8
               0xFE,0xFF,0xBF,//9
               0xFE,0xFF,0xBF,//10
               0xFE,0xFF,0xBF,//11
               0xFE,0xFF,0xBF,//12
               0xAA,0xAA,0xAA,//13
               0xFE,0xFF,0xBF,//14
               0xFE,0xFF,0xBF,//15
               0xFE,0xFF,0xBF,//16
               0xFE,0xFF,0xBF,//17
               0xFE,0xFF,0xBF,};//18 
//unsigned char Null[] = { //////////// " |"
//               0xFF,0xFF,0xFF,//1
//               0xFF,0xFF,0xFF,//2
//               0xFF,0xFF,0xFF,//3
//               0xFF,0xFF,0xFF,//4
//               0xFF,0xFF,0xFF,//5
//               0xFF,0xFF,0xFF,//6
//               0xFF,0xFF,0xFF,//7
//               0xFF,0xFF,0xFF,//8
//               0xFF,0xFF,0xFF,//9
//               0xFF,0xFF,0xFF,//10
//               0xFF,0xFF,0xFF,//11
//               0xFF,0xFF,0xFF,//12
//               0xFF,0xFF,0xFF,//13
//               0xFF,0xFF,0xFF,//14
//               0xFF,0xFF,0xFF,//15
//               0xFF,0xFF,0xFF,//16
//               0xFF,0xFF,0xFF,//17
//               0xFF,0xFF,0xFF,};//18                  
int GetIndex(char ch) 
{ 
   
   if ((ch >= 'a')  && (ch <= 'z')) 
      ch = ch - 60;
   else if ((ch >= 'A')  && (ch <= 'Z')) 
      ch = ch - 54; 
   else if ((ch >= '1')  && (ch <= '9')) 
      ch = ch - 48;
   else if (ch == '0') 
      ch = ch -38;    
   else if (ch == ' ') 
      ch = ch - 32;
   else if (ch == ':') 
      ch = ch +10;
   else if (ch == '<') 
      ch = ch +14;
   else if (ch == '>') 
      ch = ch +13;
   else if (ch == '.') 
      ch = ch +19; 
   else if (ch == ',') 
      ch = ch +25;           
   else if (ch == '+') 
      ch = ch + 161;         
   return ch; 
} 
void spi_transfer(char data)
{

  delay_us(10); 
  SPDR = data;              // Start the transmission
  while (!(SPSR & (1<<SPIF)))     // Wait the end of the transmission
  {
  };
  delay_us(10);
 
  
}
void WriteCharacter_ToMemory(char address , char data[])
{
    spi_transfer(VM0_reg);
    spi_transfer(DISABLE_display);
    spi_transfer(CMAH_reg);
    spi_transfer(address);
    
    spi_transfer(CMM_reg);
    spi_transfer(0x50);
    delay_ms(100);
    i = 0; 
    while(i<54)
    {
        spi_transfer(CMAL_reg);
        spi_transfer(i); 
        delay_ms(1);
        
        spi_transfer(CMDI_reg);
        spi_transfer(data[i]);
        delay_ms(1);
        i++;
    }  
        spi_transfer(CMM_reg);
        spi_transfer(0xA0);
        delay_ms(100);
        spi_transfer(VM0_reg);
        spi_transfer(ENABLE_display);
        delay_ms(100);
    
}
void WriteCharacter__ToScreen(char s, char x, char y)
{
  unsigned int linepos;
  char settings, char_address_hi, char_address_lo;
  char_address_hi = 0;
  linepos =(unsigned int) y*30+x;
  char_address_hi = linepos >> 8;
  char_address_lo = linepos;


  settings = 0x51;     //auto increment 0x01, 8bit 0x40
  spi_transfer(DMM_reg); //dmm
  spi_transfer(settings);

  spi_transfer(DMAH_reg); // set start address high
  spi_transfer((char_address_hi &0xFD));
  

  spi_transfer(DMAL_reg); // set start address low
  spi_transfer(char_address_lo);
  
  spi_transfer(DMDI_reg);
  SPDR = s;              // Start the transmission
  while (!(SPSR & (1<<SPIF)))     // Wait the end of the transmission
  {
  };
  spi_transfer(DMDI_reg);
  spi_transfer(END_string);

  spi_transfer(DMM_reg); //dmm
  spi_transfer(0x00);
} 

void WriteString__ToScreen(char *s, char x, char y)
{
  unsigned int linepos;
  char local_count;
  char settings, char_address_hi, char_address_lo;
  char screen_char;

  local_count = 0;

  char_address_hi = 0;
  char_address_lo = 0;
  linepos =(unsigned int) y*30+x;
  char_address_hi = linepos >> 8;
  char_address_lo = linepos;


  settings = 0x41;     //auto increment 0x01, 8bit 0x40
  spi_transfer(DMM_reg); //dmm
  spi_transfer(settings);

  spi_transfer(DMAH_reg); // set start address high
  spi_transfer((char_address_hi & 0xFD));

  spi_transfer(DMAL_reg); // set start address low
  spi_transfer(char_address_lo);

  while(s[local_count]!='\0') // write out full screen
  {
    screen_char = s[local_count];
    spi_transfer(DMDI_reg);
    spi_transfer(GetIndex(screen_char));
     local_count= local_count+1;
  }
  spi_transfer(DMDI_reg);
  spi_transfer(END_string);

  spi_transfer(DMM_reg); //dmm
  spi_transfer(0x00);
}