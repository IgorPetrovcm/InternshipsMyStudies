# include "../include/sutil.h"
# include <stdio.h>
# include <fcntl.h>
# include <string.h>
# include <sys/stat.h>
# include <sys/uio.h>
# include <unistd.h>

int main(int argc, char * argv[]){
# define STR_LENGTH 114
    int fd, openFlags, x;
    struct iovec iov[3];
    struct stat fileStat;
    char str[STR_LENGTH];
    ssize_t numRead, totalRequired;
    mode_t perms = S_IRGRP | S_IWGRP 
        | S_IRUSR | S_IWUSR;
    
    if (argc < 2 || strcmp(argv[1], "--help") == 0){
        printf("%s file_path", argv[0]);
    }

    openFlags = O_RDONLY;

    if ((fd = open(argv[1], openFlags, perms)) == -1){
        errExit("open file");
    }

    totalRequired = 0;

    iov[0].iov_base = str;
    iov[0].iov_len = STR_LENGTH;
    totalRequired += iov[0].iov_len;

    iov[1].iov_base = &x;
    iov[1].iov_len = sizeof(x);
    totalRequired += iov[1].iov_len;

    iov[2].iov_base = &fileStat;
    iov[2].iov_len = sizeof(stat);
    totalRequired += iov[2].iov_len;

    if ((numRead = readv(fd, iov, 3)) == -1){
        errExit("fragmentation read");
    }

    printf("READ %d  BYTES : REQUIRED %d BYTES\n", numRead, totalRequired);

    if (close(fd) == -1){
        errExit("file close");
    }

    printf("%s\n", str);

    printf("\n%d\n",
        x
        );
}