from ArraysAndHashing import has_duplicate
def test_has_duplicates():

    assert has_duplicate([1, 2, 3, 4, 5]) is False
    assert has_duplicate([1, 2, 3, 4, 5, 3]) is True
    assert has_duplicate(['a', 'b', 'c', 'd']) is False
    assert has_duplicate(['a', 'b', 'c', 'a']) is True
    assert has_duplicate([]) is False
    assert has_duplicate([None, None]) is True
    assert has_duplicate([1.1, 2.2, 3.3, 1.1]) is True