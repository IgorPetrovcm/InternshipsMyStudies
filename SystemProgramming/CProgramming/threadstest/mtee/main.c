# include "../include/sutil.h"
# include <string.h>
# include <fcntl.h>
# include <unistd.h>
# include <sys/stat.h>
# include <stdio.h>
# include <stdlib.h>
# include <errno.h>

# ifndef BUFF_SIZE
# define BUFF_SIZE_T 1024
# endif

int main(int argc, char * argv[]){
    char buffer[BUFF_SIZE_T];
    ssize_t numRead, numWrite;
    int fileFD, openFlags;
    mode_t perms;
    char * file_path;

    if (argc < 2 || strcmp(argv[1], "--help") == 0){
        errUsage("%s -[a] file_path\n", argv[0]);
    }

    perms = S_IWUSR | S_IRUSR | S_IWGRP | S_IRGRP | S_IWOTH | S_IROTH;
    openFlags = O_CREAT | O_WRONLY | O_TRUNC;

    file_path = argv[1];

    if (strcmp(argv[1], "-a") == 0){
        openFlags |= O_APPEND;
        openFlags = openFlags ^ O_TRUNC;
        file_path = argv[2];
    }

    if ((fileFD = open(file_path, openFlags, perms)) == -1){
        errExit("open file");
    }

    while ((numRead = read(STDIN_FILENO, buffer, BUFF_SIZE_T)) > 0){
        printf("READ %d BYTES\n", numRead);
        if ((numWrite = write(fileFD, buffer, numRead)) != numRead){
            printf("WRITE %d BYTES IN FILE\n", numWrite);
            errExit("write in file");
        }
        if ((numWrite = write(STDOUT_FILENO, buffer, numRead) != numRead)){
            printf("WRITE %d BYTES IN STDOUT\n", numWrite);
            errExit("write in out");
        }
    }

    if (close(fileFD) == -1){
        errExit("close file");
    }

    exit(EXIT_SUCCESS);
}