# include <unistd.h>
# include <string.h>
# include "../include/sutil.h"
# include <fcntl.h>
# include <sys/stat.h>

int
main(int argc, char * argv[]){
# define BUFF_SIZE 64
    int fd, buff[BUFF_SIZE], openFlags;
    mode_t perms;
    off_t offset;

    perms = S_IRGRP | S_IWGRP | S_IWUSR | S_IRUSR;
    openFlags = O_WRONLY | O_APPEND;

    if (argc < 2 || strcmp(argv[1], "--help") == 0){
        errUsage("%s file_path", argv[0]);
    }

    if ((fd = open(argv[1], openFlags, perms)) == -1){
        errExit("open file");
    }

    if ((offset = lseek(fd, 0, SEEK_SET)) == -1){
        errExit("seek in file");
    }

    if (write(fd, "Hello", 5) < 5){
        errExit("write");
    }

    close(fd);
}