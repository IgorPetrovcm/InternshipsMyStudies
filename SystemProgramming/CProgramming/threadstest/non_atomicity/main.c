# include <unistd.h>
# include <stdio.h>

int
main(int argc, char * argv[]){
    if (argc == 2){
        sleep(5);
        printf("Done sleeping");
    }

    printf("Done executing");
    
}