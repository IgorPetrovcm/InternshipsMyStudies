# include "include/tutil.h"

# include <stdio.h>
# include <stdarg.h>
# include <string.h>
# include <errno.h>

static void
outputError(const int isUseErr, int err, const int isFlushStdout, const char * format, va_list ap){
    const int BUFF_SIZE = 500;
    char result[BUFF_SIZE], userMsg[BUFF_SIZE], errText[BUFF_SIZE];

    vsnprintf(userMsg, BUFF_SIZE, format, ap);

    if (isUseErr){
        snprintf(errText, BUFF_SIZE, " [%s]", strerror(err));
    }
    else {
        snprintf(errText, BUFF_SIZE, ":");
    }

    if (isFlushStdout){
        fflush(stdout);
    }

    snprintf(result, BUFF_SIZE, "ERROR%s %s\n", errText, userMsg);
    fputs(result, stderr);
    fflush(stderr);
}

void
err_msg(const char * format, ...){
    int savedErrnum = errno;
    va_list ap;
    va_start(ap, format);
    outputError(0, savedErrnum, 0, format, ap);
    va_end(ap);
    errno = savedErrnum;
}

void
errExit(const char * format, ...){
    va_list ap;
    va_start(ap, format);
    outputError(0, errno, 0, format, ap);
    va_end(ap);
    exit(EXIT_FAILURE);
}

void
err_exit(const char * format, ...){
    va_list ap;
    va_start(ap, format);
    outputError(0, errno, 1, format, ap);
    va_end(ap);
    _exit(EXIT_FAILURE);
}

void
errExitEN(const int errnum, const char * format, ...){
    va_list ap;
    va_start(ap, format);
    outputError(0, errnum, 0, format, ap);
    va_end(ap);
    exit(EXIT_FAILURE);
}

void
fatal(const char * format, ...){
    va_list ap;
    va_start(ap, format);
    outputError(1, 0, 0, format, ap);
    va_end(ap);
    exit(EXIT_FAILURE);
}