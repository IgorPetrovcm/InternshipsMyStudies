# include "include/sutil.h"
# include <stdio.h>
# include <stdarg.h>
# include <string.h>
# include <errno.h>
# include <stdlib.h>
# include <unistd.h>

# define BUFF_SIZE 500

static
void errOutput(const int isUseErr, const int errnum, const char * format, va_list ap){
    char errMsg[BUFF_SIZE], usrMsg[BUFF_SIZE], resultMsg[BUFF_SIZE];

    vsnprintf(usrMsg, BUFF_SIZE, format, ap);

    if (isUseErr){
        snprintf(errMsg, BUFF_SIZE, " [%s]", strerror(errnum));
    }
    else {
        snprintf(errMsg, BUFF_SIZE, ":");
    }
    
    snprintf(resultMsg, BUFF_SIZE, "ERROR%s %s", errMsg, usrMsg);
    fflush(stdout);
    fputs(resultMsg, stderr);
    fflush(stderr);
}

void errExit(const char * format, ...){
    va_list ap;
    va_start(ap, format);
    errOutput(0, errno, format, ap);
    va_end(ap);
    exit(EXIT_FAILURE);
}

void err_exit(const char * format, ...){
    va_list ap;
    va_start(ap, format);
    errOutput(1, 0, format, ap);
    va_end(ap);
    _exit(EXIT_FAILURE);
}

void errUsage(const char * format, ...){
    va_list ap;
    va_start(ap, format);
    fflush(stdout);
    fprintf(stderr, "Usage: ");
    vfprintf(stderr, format, ap);
    va_end(ap);
    fflush(stderr);
    exit(EXIT_FAILURE);
}