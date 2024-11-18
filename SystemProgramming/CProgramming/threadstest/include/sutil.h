# ifndef SUTIL_H
# define SUTIL_H

# ifdef __GNUC__
# define NORETURN __attribute__((noreturn)) 
# else
# define NORETURN
# endif

void errExit(const char * format, ...) NORETURN;
void err_exit(const char * format, ...) NORETURN;
void errUsage(const char * format, ...) NORETURN;
// void errMsg(const char * format, ...) NORETURN;
void errExitEN(const int errnum, const char * format, ...) NORETURN;

# endif