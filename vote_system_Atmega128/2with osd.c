#include <mega128.h>
#include <delay.h>
#include <OSD.h>
#include <iobits.h>
#define X_1    PORTC.0
#define X_2    PORTC.1
#define X_3    PORTC.2
#define X_4    PORTC.3
#define Y_1    PINC.4
#define Y_2    PINC.5
#define Y_3    PINC.6
#define Y_4    PINC.7
#define Keypad_PORT    PORTC
#define Keypad_DDR     DDRC
#define max_Enable     PORTD.4   
char pc_position[]      = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
char A_name[]           = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
char B_name[]           = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
char C_name[]           = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
char D_name[]           = { 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
char voter_ID[]         = { 0xff, 0x06, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
char voter_code[]       = { 0xff, 0x07, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
char voter_choose[]     = { 0xff, 0x0C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00 };
char keypad_scanner();
void initilize();
void Refresh();
void write_Name_toscreen(char *name);
long int char_To_Int(char* numbre, int length);
void clear_screen(int start_col, int end_col, int start_row, int end_row);
void writelin_Toscreen(int hex, int line);
void writecol_Toscreen(int hex, int column);
void Writeint_ToScreen (long int number, int x, int y);
void write_commands();
int pc_data_rec=0;
int num_pc=0;
int candi_Num=0;
int total_voters_Num=0;
int current_voters_num=0;
int start_Proccess=0;
char key = 'n';
long int ID=0;
long int code=0;
int ID_is_entred=0;
int code_is_entred=0;
int k_ID=0;
int k_code=0;
char in_code [] = {0,0,0,0,0,0,0,0};
char in_ID[] = {0,0,0,0,0};
int ID_wait=0;
int Code_wait=0;
#define Reset PORTB.1
#ifndef RXB8
#define RXB8 1
#endif

#ifndef TXB8
#define TXB8 0
#endif

#ifndef UPE
#define UPE 2
#endif

#ifndef DOR
#define DOR 3
#endif

#ifndef FE
#define FE 4
#endif

#ifndef UDRE
#define UDRE 5
#endif

#ifndef RXC
#define RXC 7
#endif

#define FRAMING_ERROR (1<<FE)
#define PARITY_ERROR (1<<UPE)
#define DATA_OVERRUN (1<<DOR)
#define DATA_REGISTER_EMPTY (1<<UDRE)
#define RX_COMPLETE (1<<RXC)




// USART1 Receiver buffer
#define RX_BUFFER_SIZE1 8
char rx_buffer1[RX_BUFFER_SIZE1];

#if RX_BUFFER_SIZE1 <= 256
unsigned char rx_wr_index1,rx_rd_index1,rx_counter1;
#else
unsigned int rx_wr_index1,rx_rd_index1,rx_counter1;
#endif

// This flag is set on USART1 Receiver buffer overflow
bit rx_buffer_overflow1;

// USART1 Receiver interrupt service routine
interrupt [USART1_RXC] void usart1_rx_isr(void)
{
char status,data;
status=UCSR1A;
data=UDR1;
if(num_pc ==9)
{
    pc_position[9] = data;  
    pc_data_rec=1;
    num_pc=0;     
}
if(num_pc ==8)
{
    pc_position[8] = data;
    num_pc++;
}
if(num_pc ==7)
{
    pc_position[7] = data;
    num_pc++;
}
if(num_pc ==6)
{
    pc_position[6] = data;
    num_pc++;
}
if(num_pc ==5)
{
    pc_position[5] = data;
    num_pc++;
}
if(num_pc ==4)
{
    pc_position[4] = data;
    num_pc++;
}
if(num_pc ==3)
{
    pc_position[3] = data;
    num_pc++;
}
if(num_pc ==2)
{
    pc_position[2] = data;
    num_pc++;
}
if(num_pc ==1)
{
    pc_position[1] = data;
    num_pc++;
} 
     
if(data == 0xFF)
{
    pc_position[0] = data;
    num_pc++;
}
if ((status & (FRAMING_ERROR | PARITY_ERROR | DATA_OVERRUN))==0)
   {
   rx_buffer1[rx_wr_index1++]=data;
#if RX_BUFFER_SIZE1 == 256
   // special case for receiver buffer size=256
   if (++rx_counter1 == 0) rx_buffer_overflow1=1;
#else
   if (rx_wr_index1 == RX_BUFFER_SIZE1) rx_wr_index1=0;
   if (++rx_counter1 == RX_BUFFER_SIZE1)
      {
      rx_counter1=0;
      rx_buffer_overflow1=1;
      }
#endif
   }
}

// Get a character from the USART1 Receiver buffer
#pragma used+
char getchar1(void)
{
char data;
while (rx_counter1==0);
data=rx_buffer1[rx_rd_index1++];
#if RX_BUFFER_SIZE1 != 256
if (rx_rd_index1 == RX_BUFFER_SIZE1) rx_rd_index1=0;
#endif
#asm("cli")
--rx_counter1;
#asm("sei")
return data;
}
#pragma used-
// USART1 Transmitter buffer
#define TX_BUFFER_SIZE1 8
char tx_buffer1[TX_BUFFER_SIZE1];

#if TX_BUFFER_SIZE1 <= 256
unsigned char tx_wr_index1,tx_rd_index1,tx_counter1;
#else
unsigned int tx_wr_index1,tx_rd_index1,tx_counter1;
#endif

// USART1 Transmitter interrupt service routine
interrupt [USART1_TXC] void usart1_tx_isr(void)
{
if (tx_counter1)
   {
   --tx_counter1;
   UDR1=tx_buffer1[tx_rd_index1++];
#if TX_BUFFER_SIZE1 != 256
   if (tx_rd_index1 == TX_BUFFER_SIZE1) tx_rd_index1=0;
#endif
   }
}

// Write a character to the USART1 Transmitter buffer
#pragma used+
void putchar1(char c)
{
while (tx_counter1 == TX_BUFFER_SIZE1);
#asm("cli")
if (tx_counter1 || ((UCSR1A & DATA_REGISTER_EMPTY)==0))
   {
   tx_buffer1[tx_wr_index1++]=c;
#if TX_BUFFER_SIZE1 != 256
   if (tx_wr_index1 == TX_BUFFER_SIZE1) tx_wr_index1=0;
#endif
   ++tx_counter1;
   }
else
   UDR1=c;
#asm("sei")
}
#pragma used-

#define ADC_VREF_TYPE 0x00
// Read the 8 most significant bits
// of the AD conversion result


// SPI functions
#include <spi.h>
void send_frame(char *frame, int length)
{  
    int i;
    max_Enable=1;
    if (frame[1]==0x06){ID_wait=1;}
    if (frame[1]==0x07){Code_wait=1;}
    for (i=0;i<length;i++)
    {
        putchar1 (frame[i]);
        delay_us(10);
    }
    delay_ms(50);
    max_Enable=0; 
}
// Declare your global variables here
void main(void)
{
// Declare your local variables here

// Input/Output Ports initialization
// Port A initialization
// Func7=In Func6=In Func5=In Func4=In Func3=In Func2=Out Func1=In Func0=In 
// State7=T State6=T State5=T State4=T State3=T State2=0 State1=T State0=T 
PORTA=0x00;
DDRA=0x44;

// Port B initialization
// Func7=Out Func6=Out Func5=Out Func4=Out Func3=In Func2=Out Func1=Out Func0=Out 
// State7=0 State6=0 State5=0 State4=0 State3=T State2=0 State1=0 State0=0 
PORTB=0x00;
DDRB=0xF7;

// Port C initialization
// Func7=In Func6=In Func5=In Func4=In Func3=In Func2=In Func1=In Func0=In 
// State7=P State6=P State5=P State4=P State3=P State2=P State1=P State0=P 
PORTC=0xF0;
DDRC=0x0F;

// Port D initialization
// Func7=In Func6=In Func5=In Func4=In Func3=In Func2=In Func1=In Func0=In 
// State7=T State6=T State5=T State4=T State3=T State2=T State1=T State0=T 
PORTD=0x00;
DDRD=0xFF;

// Port E initialization
// Func7=In Func6=In Func5=In Func4=In Func3=In Func2=In Func1=In Func0=In 
// State7=T State6=T State5=T State4=T State3=T State2=T State1=T State0=T 
PORTE=0x00;
DDRE=0x00;

// Port F initialization
// Func7=In Func6=Out Func5=In Func4=In Func3=In Func2=In Func1=In Func0=Out 
// State7=T State6=0 State5=T State4=T State3=T State2=T State1=T State0=1 
//PORTF=0x41;
//DDRF=0x41;
  PORTF=0x00;
DDRF=0x43;

// Port G initialization
// Func4=In Func3=In Func2=In Func1=In Func0=In 
// State4=T State3=T State2=T State1=T State0=T 
PORTG=0x00;
DDRG=0x00;

// Timer/Counter 0 initialization
// Clock source: System Clock
// Clock value: Timer 0 Stopped
// Mode: Normal top=0xFF
// OC0 output: Disconnected
ASSR=0x00;
TCCR0=0x00;
TCNT0=0x00;
OCR0=0x00;

// Timer/Counter 1 initialization
// Clock source: System Clock
// Clock value: Timer1 Stopped
// Mode: Normal top=0xFFFF
// OC1A output: Discon.
// OC1B output: Discon.
// OC1C output: Discon.
// Noise Canceler: Off
// Input Capture on Falling Edge
// Timer1 Overflow Interrupt: Off
// Input Capture Interrupt: Off
// Compare A Match Interrupt: Off
// Compare B Match Interrupt: Off
// Compare C Match Interrupt: Off
TCCR1A=0x00;
TCCR1B=0x00;
TCNT1H=0x00;
TCNT1L=0x00;
ICR1H=0x00;
ICR1L=0x00;
OCR1AH=0x00;
OCR1AL=0x00;
OCR1BH=0x00;
OCR1BL=0x00;
OCR1CH=0x00;
OCR1CL=0x00;

// Timer/Counter 2 initialization
// Clock source: System Clock
// Clock value: 1000.000 kHz
// Mode: Normal top=0xFF
// OC2 output: Disconnected
TCCR2=0x00;
TCNT2=0x00;
OCR2=0x00;

// Timer/Counter 3 initialization
// Clock source: System Clock
// Clock value: Timer3 Stopped
// Mode: Normal top=0xFFFF
// OC3A output: Discon.
// OC3B output: Discon.
// OC3C output: Discon.
// Noise Canceler: Off
// Input Capture on Falling Edge
// Timer3 Overflow Interrupt: Off
// Input Capture Interrupt: Off
// Compare A Match Interrupt: Off
// Compare B Match Interrupt: Off
// Compare C Match Interrupt: Off
TCCR3A=0x00;
TCCR3B=0x00;
TCNT3H=0x00;
TCNT3L=0x00;
ICR3H=0x00;
ICR3L=0x00;
OCR3AH=0x00;
OCR3AL=0x00;
OCR3BH=0x00;
OCR3BL=0x00;
OCR3CH=0x00;
OCR3CL=0x00;

// External Interrupt(s) initialization
// INT0: Off
// INT1: Off
// INT2: Off
// INT3: Off
// INT4: Off
// INT5: Off
// INT6: Off
// INT7: Off
EICRA=0x00;
EICRB=0x00;
EIMSK=0x00;

// Timer(s)/Counter(s) Interrupt(s) initialization
TIMSK=0x40;

ETIMSK=0x00;

// USART0 initialization
// USART0 disabled
UCSR0B=0x00;

// USART1 initialization
// Communication Parameters: 8 Data, 1 Stop, No Parity
// USART1 Receiver: On
// USART1 Transmitter: On
// USART1 Mode: Asynchronous
// USART1 Baud Rate: 9600
UCSR1A=0x00;
UCSR1B=0xD8;
UCSR1C=0x06;
UBRR1H=0x00;
UBRR1L=0x33;

// Analog Comparator initialization
// Analog Comparator: Off
// Analog Comparator Input Capture by Timer/Counter 1: Off
ACSR=0x80;
SFIOR=0x00;

// ADC initialization
// ADC Clock frequency: 1000.000 kHz
// ADC Voltage Reference: AREF pin
ADMUX=ADC_VREF_TYPE & 0xff;
ADCSRA=0x00;

// SPI initialization
// SPI Type: Master
// SPI Clock Rate: 2000.000 kHz
// SPI Clock Phase: Cycle Half
// SPI Clock Polarity: Low
// SPI Data Order: MSB First
SPCR=0x53;
SPSR=0x00;

// TWI initialization
// TWI disabled
TWCR=0x00;


OSD_nCS=1;
delay_ms(50);
OSD_nCS=0;
delay_ms(50);
OSD_nReset=0;
delay_ms(100);
OSD_nReset=1;
delay_ms(100);

spi_transfer(VM0_reg);
spi_transfer(ENABLE_display); 
WriteCharacter_ToMemory(0x81,dash);
WriteCharacter_ToMemory(0x82,dash_Ver);
WriteCharacter_ToMemory(0x83,star);
WriteCharacter_ToMemory(0x80,sharp);               
initilize();
// Global enable interrupts
#asm("sei")

while(1)
{          
            if(current_voters_num == total_voters_Num && start_Proccess ==1 && pc_data_rec == 0)
            {
                clear_screen(1,30,4,15);
                initilize();
                Refresh();
            }
            if(pc_data_rec == 1)
            {
                write_commands();
            }
            else if(start_Proccess == 1 && ID_is_entred == 0 && code_is_entred == 0 && ID_wait == 0 && pc_data_rec == 0)
            {
                while(key!=0x83 && k_ID < 5 && pc_data_rec == 0)
                {
                    key = keypad_scanner();
                    if(key!=0x83 && key!='n' && key!=0x80 && key<11)
                    {
                        WriteCharacter__ToScreen(key,k_ID+1,8);  
                        in_ID[k_ID]=key;
                        k_ID++;
                    }
                } 
                    ID = char_To_Int(in_ID,k_ID);
                    voter_ID[2]=ID/256;
                    voter_ID[3]=ID%256;
                    send_frame(voter_ID,10);
                    WriteString__ToScreen("Wait...",1,9);
                if(pc_data_rec == 1)
                {
                    write_commands();
                }
            } 
            else if(start_Proccess==1 && ID_is_entred == 1 && code_is_entred == 0 && Code_wait == 0 && pc_data_rec == 0)
            {
                WriteString__ToScreen("Entre your Code:",1,10);
                while(key!=0x83 && k_code < 8)
                {
                    key = keypad_scanner();
                    if(key!=0x83 && key!='n' && key!=0x80 && key<11)
                    {
                        WriteCharacter__ToScreen(key,k_code+1,11);  
                        in_code[k_code]=key;
                        k_code++;
                    }
                }
                code = char_To_Int(in_code,k_code);
                voter_code[2]=code/65536;
                voter_code[3]=(code%65536)/256;
                voter_code[4]=(code%65536)%256;
                send_frame(voter_code,10);
                WriteString__ToScreen("Wait...",1,12);
            }
            else if(start_Proccess==1 && ID_is_entred == 1 && code_is_entred == 1 && pc_data_rec == 0)
            {
                
                while(key!=0x83)
                {
                    WriteString__ToScreen("Vote Now:",1,13);
                    key = keypad_scanner();
                    if(key!=0x83 && key!='n' && key!=0x80 && key>10)
                    {
                        if(key > candi_Num + 10)
                        {
                            WriteString__ToScreen("Invalid Candi",1,13);
                            WriteString__ToScreen("Revote Please",1,14);
                            delay_ms(1000);
                            clear_screen(1,17,13,14);
                        }
                        else
                        {
                            WriteString__ToScreen("You Voted For:",1,14);
                            WriteCharacter__ToScreen(key,15,14);
                            current_voters_num++;
                            Writeint_ToScreen(current_voters_num,13,5);
                            voter_choose[2]=key-10;
                            send_frame(voter_choose,10);
                            delay_ms(1000);
                            Refresh(); 
                            break;
                        }    
                    } 
                }
            }           
}
}

void initilize()
{ 
    WriteString__ToScreen("Syrian Arab Republic",1,1);
    WriteString__ToScreen("Damascus University",1,2);
    WriteString__ToScreen("Project Voting",1,3);
    delay_ms(3000);
    clear_screen(1,28,1,3);
    WriteString__ToScreen("Hanadi , Boushra",7,8);
    delay_ms(3000);
    clear_screen(1,28,1,8); 
    WriteString__ToScreen("Automated Voting System",1,1);
    WriteString__ToScreen("Hanadi , Boushra",1,2);
    writelin_Toscreen(0x81,3);
    writecol_Toscreen(0x82,18);
    WriteString__ToScreen("Please Set Candi",1,4);
    WriteString__ToScreen("Names",1,5);
    candi_Num=0;
    total_voters_Num=0;
    current_voters_num=0;
    start_Proccess=0;
}

void clear_screen(int start_col, int end_col, int start_row, int end_row)
{
    int i=0;
    int j=0;
    for(i=start_row;i<=end_row;i++)
    {
        for(j=start_col;j<=end_col;j++)
        {  
          WriteCharacter__ToScreen(0x84,j,i);
        }
    }
}

void writelin_Toscreen(int hex, int line)
{
    int i=0;
    for(i=1;i<=28;i++)
    {
      WriteCharacter__ToScreen(hex,i,line); 
    }
}

void writecol_Toscreen(int hex, int column)
{
    int i=0;
    for(i=4;i<=14;i++)
    {
      WriteCharacter__ToScreen(hex,column,i); 
    }
}

void Writeint_ToScreen (long int number, int x, int y)
{
    if(number==0)
    {   
         WriteCharacter__ToScreen(10,x,y);
    }
    else
    {
        long int num = number;
        int length = 0;
        long int tens=1;
        int i=1;
        while(number>0)
        {
            number=number/10;
            length++;
            tens=tens*10;
        }
        for(i=1;i<=length;i++)
        {   
            tens=tens/10;
            number=num%tens;
            num=num/tens;
            if(num==0) num=10;
            WriteCharacter__ToScreen(num,x+i-1,y); 
            num= number;     
        }
    }
}

char keypad_scanner()  
{            
    X_1 = 0; X_2 = 1; X_3 = 1; X_4 = 1;    
    if (Y_1 == X_1) { delay_ms(100); while (Y_1 == X_1); return 1; }
    if (Y_2 == X_1) { delay_ms(100); while (Y_2 == X_1); return 2; }
    if (Y_3 == X_1) { delay_ms(100); while (Y_3 == X_1); return 3; }
    if (Y_4 == X_1) { delay_ms(100); while (Y_4 == X_1); return 11; }
            
    X_1 = 1; X_2 = 0; X_3 = 1; X_4 = 1;    
    if (Y_1 == X_2) { delay_ms(100); while (Y_1 == X_2); return 4;}
    if (Y_2 == X_2) { delay_ms(100); while (Y_2 == X_2); return 5; }
    if (Y_3 == X_2) { delay_ms(100); while (Y_3 == X_2); return 6; }
    if (Y_4 == X_2) { delay_ms(100); while (Y_4 == X_2); return 12; }
            
    X_1 = 1; X_2 = 1; X_3 = 0; X_4 = 1;    
    if (Y_1 == X_3) { delay_ms(100); while (Y_1 == X_3); return 7;}
    if (Y_2 == X_3) { delay_ms(100); while (Y_2 == X_3); return 8; }
    if (Y_3 == X_3) { delay_ms(100); while (Y_3 == X_3); return 9; }
    if (Y_4 == X_3) { delay_ms(100); while (Y_4 == X_3); return 13; }
            
    X_1 = 1; X_2 = 1; X_3 = 1; X_4 = 0;    
    if (Y_1 == X_4) { delay_ms(100); while (Y_1 == X_4); return 0x83;}
    if (Y_2 == X_4) { delay_ms(100); while (Y_2 == X_4); return 10; }
    if (Y_3 == X_4) { delay_ms(100); while (Y_3 == X_4); return 0x80; }
    if (Y_4 == X_4) { delay_ms(100); while (Y_4 == X_4); return 14; }
    return 'n';                   
}

void write_commands()
{
     int i=0;
     if(pc_position[1] == 0x01)
     {
        clear_screen(1,17,4,5);
        WriteString__ToScreen("Please, Load",1,4);
        WriteString__ToScreen("Voters Numbre",1,5);
        WriteString__ToScreen("Candi IDs",19,4);
        WriteString__ToScreen("A:",19,5);
        for(i=0;i<10;i++){A_name[i]=pc_position[i];}
        write_Name_toscreen(A_name);
        pc_data_rec = 0; 
     }
     if(pc_position[1] == 0x02)
     {
        WriteString__ToScreen("B:",19,6);
        for(i=0;i<10;i++){B_name[i]=pc_position[i];}
        write_Name_toscreen(B_name);
        pc_data_rec = 0; 
     }
     if(pc_position[1] == 0x03)
     {
        WriteString__ToScreen("C:",19,7);
        for(i=0;i<10;i++){C_name[i]=pc_position[i];}
        write_Name_toscreen(C_name);
        pc_data_rec = 0; 
     }
     if(pc_position[1] == 0x04)
     {
        WriteString__ToScreen("D:",19,8);
        for(i=0;i<10;i++){D_name[i]=pc_position[i];}
        write_Name_toscreen(D_name);
        pc_data_rec = 0; 
     }
     if(pc_position[1] == 0x05)
     {
        clear_screen(1,17,4,5);
        total_voters_Num= (pc_position[2] * 256) + pc_position[3];
        WriteString__ToScreen("Voters Num:",1,4);
        Writeint_ToScreen(total_voters_Num,12,4);
        WriteString__ToScreen("Curr Voters:",1,5);
        Writeint_ToScreen(current_voters_num,13,5);
        pc_data_rec = 0;
     }
     if(pc_position[1] == 0x0D)
     {
        start_Proccess = 1;
        WriteString__ToScreen("Voting Start...",1,6);
        WriteString__ToScreen("Entre your ID:",1,7);
        pc_data_rec = 0;
     }
     if(pc_position[1] == 0x08)
     {
        WriteString__ToScreen("ID is: ",1,9);
        Writeint_ToScreen(ID,8,9);
        ID_is_entred = 1;
        ID_wait=0;
        pc_data_rec = 0;
     }
     if(pc_position[1] == 0x0A)
     {
        WriteString__ToScreen("ID is Wrong ",1,9); 
        delay_ms(1000);
        Refresh();
        ID_wait=0;
        pc_data_rec = 0;
     }
     if(pc_position[1] == 0x0E)
     {
        WriteString__ToScreen("ID is Already ",1,9);
        WriteString__ToScreen("Voted ",1,10); 
        delay_ms(1000);
        Refresh();
        ID_wait=0;
        pc_data_rec = 0;
     }
     if(pc_position[1] == 0x09)
     {
        WriteString__ToScreen("Code is:",1,12);
        Writeint_ToScreen(code,9,12);
        code_is_entred = 1;
        Code_wait=0;
        pc_data_rec = 0;
     }
     if(pc_position[1] == 0x0B)
     {
        WriteString__ToScreen("Code is Wrong ",1,12); 
        delay_ms(1000);
        Refresh();
        Code_wait=0;
        pc_data_rec = 0;
     }
     if(pc_position[1] == 0x0F)
     {
        clear_screen(1,30,4,15);
        initilize(); 
        Refresh();
        pc_data_rec = 0;
     }
}

void write_Name_toscreen(char *name)
{
    int i=0;
    int num=0;
    int j=0;
    int row=name[1];
    candi_Num++;
    for(i=2;i<10;i++)
    {
        if(name[i]!=0x00)
        {
            num = GetIndex(name[i]);
            WriteCharacter__ToScreen(num,21+j,4+row);
            j++;
        }
        else
            break;
    }
} 

long int char_To_Int(char* numbre, int length)
{
     int i=0;
     long int num=0; 
     long int ten=1;
     char zero=0;
     for(i=length-1;i>=0;i--)
     {
        if (numbre[i]!=10)
        {
            num = num + ((numbre[i] - zero) * ten);
        }
        ten=ten*10;
     }
     return num;
}    

void Refresh()
{
    clear_screen(1,17,8,16);
    pc_data_rec=0;
    num_pc=0;
    ID=0;
    code=0;
    ID_is_entred=0;
    code_is_entred=0;
    k_ID=0;
    k_code=0;
    in_code[0] = 0;
    in_code[1] = 0;
    in_code[2] = 0;
    in_code[3] = 0;
    in_code[4] = 0;
    in_code[5] = 0;
    in_code[6] = 0;
    in_code[7] = 0;
    in_ID[0] = 0;
    in_ID[1] = 0;
    in_ID[2] = 0;
    in_ID[3] = 0;in_ID[4] = 0;
    ID_wait=0;
    Code_wait=0;
}

