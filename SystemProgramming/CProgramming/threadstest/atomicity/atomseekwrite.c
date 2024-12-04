# include <unistd.h>
# include <stdio.h>
# include <string.h>
# include <fcntl.h>
# include <sys/stat.h>
// # include <stdlib.h>
# include "../include/sutil.h"

int
main(int argc, char * argv[]){
# define BUFF_SIZE 64
    int fd, openFlags;
    char buff[BUFF_SIZE];
    mode_t perms;
    off_t offset;

    perms = S_IRUSR | S_IWUSR | S_IRGRP | S_IWGRP;

    for (int i = 0; i < BUFF_SIZE; i++){
        buff[i] = i + 33;
    }

    if (argc < 2 || strcmp(argv[1], "--help") == 0){
        errUsage("%s file_path", argv[0]);
    }

    if ((fd = open(argv[1], O_CREAT | O_WRONLY | O_TRUNC, perms)) == -1){
        errExit("open [%s]", argv[1]);
    }

    if ((offset = lseek(fd, 0, SEEK_END)) == -1){
        errExit("seek in [%s] to end", argv[1]);
    }
    if (argc == 3){
        int flags = fcntl(fd, F_GETFL);
        if (flags == -1){
            errExit("read of [%s] open flags", argv[1]);
        }

        flags |= O_APPEND;
        if (fcntl(fd, F_SETFL, flags) == -1){
            errExit("set for [%s] open flags", argv[1]);
        }

        sleep(5);
    }
    if (write(fd, buff, BUFF_SIZE) != BUFF_SIZE){
        errExit("write");
    }
}