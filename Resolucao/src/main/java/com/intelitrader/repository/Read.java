package com.intelitrader.repository;

import java.util.List;

public interface Read<T> {
    List<T> getAll();
}
