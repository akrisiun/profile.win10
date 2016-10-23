git reset --hard HEAD

@call git submodule update --init --recursive
@call git fetch --all
@call git reset HEAD --hard

@PAUSE