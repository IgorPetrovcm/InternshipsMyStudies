# include "../include/sutil.h"
# include <string.h>
# include <fcntl.h>
# include <sys/stat.h>
# include <stdlib.h>
# include <stdio.h>
# include <unistd.h>
# include <ctype.h>

long long
getLong(const char * text, const unsigned int whence){
    for (int i = 0; i < whence; i++){
        long long value;
        
        if (*++text == '\0') {
            err_exit("conversion to long error in %lu offset");
        }

        value = atol(text);
        if (value == 0){
            err_exit("conversion to long error");
        }

        return value;
    }
}

int main(int argc, char * argv[]){
    int fileFD;
    ssize_t numRead, numWrite; // ssize_t [ -1 .. SIZE_MAX ] vs size_t [ 0 .. SIZE_MAX ]
    off_t offset;
    long buffSize;
    char * buffer;
    register int i, j, ap;
    
    if (argc < 3 || strcmp(argv[1], "--help") == 0){
        errUsage("%s file_path [ r | R | c | s ]\n", argv[0]);
    }

    fileFD = open(argv[1], O_CREAT | O_RDWR,
        S_IRUSR | S_IWUSR | S_IRGRP | S_IWGRP); 

    for (ap = 2; ap < argc; ap++){
        switch (argv[ap][0]){
            case 'r':
            case 'R':
                buffSize = (long)getLong(argv[ap], 1);
                buffer = (char *)malloc(buffSize);

                if ((numRead = read(fileFD, buffer, buffSize)) == -1){
                    errExit("read");
                }

                printf("[%s] READ TEXT:\n", argv[1]);
                for (i = 0; i < numRead; i++){
                    if (argv[ap][0] == 'r'){
                        printf("%c", isprint(buffer[i])
                            ? buffer[i]
                            : '#');
                    }
                    else {
                        printf("%02x", (unsigned int) buffer[i]);
                    }
                }
                printf("\n");

                free(buffer);
                break;
            
            case 's':
                offset = getLong(argv[ap], 1);
                long offNum = (long)lseek(fileFD, offset, SEEK_SET);
                if (offNum == -1){
                    errExit("seek fault");
                }
                printf("[%s] SEEK IN TEXT WITH AN OFFSET OF %lu\n", argv[1], offNum);
                break;

            case 'w':   
                if ((numWrite = write(fileFD, &argv[ap][1], strlen(&argv[ap][1]))) == -1){
                    errExit("write failure");
                }

                printf("[%s] WRITE %d BYTES IN FILE\n", argv[1], numWrite);
                break;

            default:
                errUsage("%s file_path [ r | R | c | s ]\n", argv[0]);
        }

        if (close(fileFD) == -1){
            errExit("close");
        }

        exit(EXIT_SUCCESS);
    }
}