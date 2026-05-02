package com.intelitrader.repository;

import java.util.Collection;

public interface Write<T>{
    void saveAll(Collection<T> objects);
}
