# include <stdlib.h>
# include <stdio.h>
# include <search.h>
# include <stdnoreturn.h>
# include <errno.h>

// void * xmalloc(size_t size){
//     register void * reserved = malloc(size);
//     if (reserved == 0) fatal("Memory error", ENOMEM);
//     return reserved;
// }

int main(){
    int a = 0;
    int b = 1;

    if (a){
        printf("Yes");
    }
    if (b){
        printf("Yes");
    }
}