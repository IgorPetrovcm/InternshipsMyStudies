# include "../include/sutil.h"
// # include <semaphore.h>
# include <string.h>
# include <stdlib.h>
# include <stdio.h>
# include <sys/stat.h>
# include <fcntl.h>
# include <unistd.h>

# ifndef BUFF_SIZE
# define BUFF_SIZE 1024
# endif

int main(int args, char * argv[]){
    int oldFileFD, newFileFD, openFlags, numOfRead;
    struct stat statBuffer;
    mode_t filePerms;
    char buf[BUFF_SIZE];
    
    if (args != 3 || strcmp(argv[1], "--help") == 0){
        errUsage("%s old-file new-file", argv[0]);
    }

    oldFileFD = open(argv[1], O_RDONLY);
    if (oldFileFD == -1){
        errExit("opening file %s", argv[1]);
    }

    if (stat(argv[1], &statBuffer)  == -1){
        errExit("stat file %s", argv[1]);
    }

    openFlags = O_CREAT | O_WRONLY | O_TRUNC;
    filePerms = S_IRUSR | S_IWUSR | S_IRGRP | S_IWGRP
        | S_IROTH | S_IWOTH;
    
    if (statBuffer.st_mode & S_IXUSR) filePerms = filePerms | S_IXUSR;
    if (statBuffer.st_mode & S_IXOTH) filePerms = filePerms | S_IXOTH;

    newFileFD = open(argv[2], openFlags, filePerms);
    if (newFileFD == -1){
        errExit("opening file %s", argv[2]);
    }

    int numOfWrite = 0;
    while ((numOfRead = read(oldFileFD, buf, BUFF_SIZE)) > 0){
        printf("READ: %dB\n", numOfRead);
        if ((numOfWrite = write(newFileFD, buf, numOfRead)) != numOfRead){
            printf("WRITE: %dB\n", numOfWrite);
            errExit("coulnd't write whole buffer");
        }
        printf("WRITE: %dB\n", numOfWrite);
    }
    if (numOfRead == -1){
        errExit("read");
    }
    if (close(newFileFD) == -1){
        errExit("close new file");
    }
    if (close(oldFileFD) == -1){
        errExit("close old file");
    }

    exit(EXIT_SUCCESS);
}