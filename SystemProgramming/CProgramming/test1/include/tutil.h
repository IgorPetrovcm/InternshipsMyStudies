# ifndef TUTIL_H
# define TUTIL_H

# include <stdlib.h>

void err_msg(const char * format, ...);

# ifdef __GNUC__
# define NORETURN __attribute__((noreturn))
# else
# define NORETURN
# endif

void errExit(const char * format, ...) NORETURN;
void err_exit(const char * format, ...) NORETURN;
void errExitEN(const int errnum, const char * format, ...) NORETURN;
void fatal(const char * format, ...) NORETURN;
void * xmalloc(const size_t size);

# endif